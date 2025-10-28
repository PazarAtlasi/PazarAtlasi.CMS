# Güvenlik Geliştirme Önerileri

## 1. Authentication & Authorization

### JWT Token Implementation

```csharp
public class JwtService
{
    private readonly IConfiguration _configuration;

    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddHours(24),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
```

### Role-Based Authorization

```csharp
[Authorize(Roles = "Admin,Editor")]
[HttpPost("section")]
public async Task<IActionResult> CreateSection([FromBody] SectionRequest request)
{
    // Only Admin and Editor can create sections
}

[Authorize(Policy = "CanEditContent")]
[HttpPut("section/{id}")]
public async Task<IActionResult> UpdateSection(int id, [FromBody] SectionRequest request)
{
    // Custom policy for content editing
}
```

## 2. Input Validation & Sanitization

### FluentValidation

```csharp
public class SectionRequestValidator : AbstractValidator<SectionRequest>
{
    public SectionRequestValidator()
    {
        RuleFor(x => x.Key)
            .NotEmpty()
            .Matches("^[a-z0-9-]+$")
            .WithMessage("Section key can only contain lowercase letters, numbers and hyphens");

        RuleFor(x => x.Type)
            .IsInEnum()
            .WithMessage("Invalid section type");

        RuleForEach(x => x.SectionItems)
            .SetValidator(new SectionItemValidator());
    }
}
```

### HTML Sanitization

```csharp
public class HtmlSanitizer
{
    private readonly HtmlSanitizer _sanitizer;

    public HtmlSanitizer()
    {
        _sanitizer = new Ganss.XSS.HtmlSanitizer();
        _sanitizer.AllowedTags.Clear();
        _sanitizer.AllowedTags.Add("p");
        _sanitizer.AllowedTags.Add("br");
        _sanitizer.AllowedTags.Add("strong");
        _sanitizer.AllowedTags.Add("em");
    }

    public string Sanitize(string html)
    {
        return _sanitizer.Sanitize(html);
    }
}
```

## 3. CSRF Protection

### Anti-Forgery Tokens

```csharp
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> SaveSection([FromBody] SectionRequest request)
{
    // CSRF protection enabled
}
```

## 4. Content Security Policy (CSP)

### CSP Headers

```csharp
public void Configure(IApplicationBuilder app)
{
    app.Use(async (context, next) =>
    {
        context.Response.Headers.Add("Content-Security-Policy",
            "default-src 'self'; " +
            "script-src 'self' 'unsafe-inline' 'unsafe-eval'; " +
            "style-src 'self' 'unsafe-inline'; " +
            "img-src 'self' data: https:; " +
            "font-src 'self' https://fonts.gstatic.com;");

        await next();
    });
}
```

## 5. File Upload Security

### Secure File Upload

```csharp
public class SecureFileUploadService
{
    private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
    private readonly string[] _allowedMimeTypes = { "image/jpeg", "image/png", "image/gif", "image/webp" };

    public async Task<UploadResult> UploadImageAsync(IFormFile file)
    {
        // Validate file extension
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!_allowedExtensions.Contains(extension))
        {
            return new UploadResult { Success = false, Message = "Invalid file type" };
        }

        // Validate MIME type
        if (!_allowedMimeTypes.Contains(file.ContentType))
        {
            return new UploadResult { Success = false, Message = "Invalid MIME type" };
        }

        // Validate file size (max 5MB)
        if (file.Length > 5 * 1024 * 1024)
        {
            return new UploadResult { Success = false, Message = "File too large" };
        }

        // Generate secure filename
        var fileName = $"{Guid.NewGuid()}{extension}";
        var filePath = Path.Combine("uploads", "images", fileName);

        // Save file
        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        return new UploadResult
        {
            Success = true,
            Url = $"/uploads/images/{fileName}",
            FileName = fileName
        };
    }
}
```
