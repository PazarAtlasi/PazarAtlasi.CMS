Do not return new {} like object.
 /// <summary>
 /// Get reusable sections for page creation
 /// </summary>
 [HttpGet]
 public async Task<IActionResult> GetReusableSections()
 {
     try
     {
         var sections = await _pazarAtlasiDbContext.Sections
             .Where(s => s.PageId == null && s.Status == Status.Active) // Reusable and active sections
             .Include(s => s.Translations)
             .Select(s => new
             {
                 id = s.Id,
                 name = s.Translations.FirstOrDefault() != null ? s.Translations.FirstOrDefault()!.Title : $"Section {s.Id}",
                 type = s.Type.ToString(),
                 templateType = s.SectionTemplateType.ToString(),
                 description = s.Translations.FirstOrDefault() != null ? s.Translations.FirstOrDefault()!.Description : ""
             })
             .OrderBy(s => s.name)
             .ToListAsync();

         return Json(new { success = true, sections = sections });
     }
     catch (Exception ex)
     {
         return Json(new { success = false, message = "An error occurred: " + ex.Message });
     }
 }

For instance in here, it is returned as new.
Instead of that, create a new dto or viewmodel, and return it.

