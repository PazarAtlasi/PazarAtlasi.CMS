// Layout Builder JavaScript
let availableSections = [];
let layoutSections = [];

// Load available sections
async function loadAvailableSections() {
  try {
    const response = await fetch("/Content/GetReusableSections");
    const result = await response.json();

    if (result.success && result.sections) {
      availableSections = result.sections;
      renderAvailableSections();
    }
  } catch (error) {
    console.error("Error loading sections:", error);
    document.getElementById("availableSections").innerHTML = `
            <div class="text-center py-4 text-red-400">
                <i class="fas fa-exclamation-circle text-2xl mb-2"></i>
                <p class="text-sm">Error loading sections</p>
            </div>
        `;
  }
}

// Render available sections
function renderAvailableSections() {
  const container = document.getElementById("availableSections");

  if (availableSections.length === 0) {
    container.innerHTML = `
            <div class="text-center py-4 text-slate-400">
                <i class="fas fa-layer-group text-2xl mb-2"></i>
                <p class="text-sm">No sections available</p>
                <a href="/Content/CreateSection" class="text-purple-600 hover:text-purple-800 text-xs">Create sections first</a>
            </div>
        `;
    return;
  }

  container.innerHTML = availableSections
    .map(
      (section) => `
         <div class="section-item bg-white border border-slate-200 rounded-lg p-3 cursor-move hover:border-purple-300 transition-colors"
              draggable="true" 
              ondragstart="dragStart(event)"
              data-section-id="${section.Id}"
              data-section-name="${section.Name}"
              data-section-type="${section.Type}">
             <div class="flex items-center">
                 <div class="w-8 h-8 bg-purple-100 rounded flex items-center justify-center mr-3">
                     <i class="fas fa-layer-group text-purple-600 text-sm"></i>
                 </div>
                 <div class="flex-1">
                     <p class="text-sm font-medium text-slate-800">${section.Name}</p>
                     <p class="text-xs text-slate-500">${section.Type}</p>
                 </div>
                 <i class="fas fa-grip-vertical text-slate-400"></i>
             </div>
         </div>
    `
    )
    .join("");
}

// Drag and Drop Functions
function dragStart(event) {
  const sectionId =
    event.target.closest(".section-item").dataset.sectionId;
  const sectionName =
    event.target.closest(".section-item").dataset.sectionName;
  const sectionType =
    event.target.closest(".section-item").dataset.sectionType;

  event.dataTransfer.setData(
    "text/plain",
    JSON.stringify({
      Id: sectionId,
      Name: sectionName,
      Type: sectionType,
    })
  );
}

function allowDrop(event) {
  event.preventDefault();
}

function drop(event) {
  event.preventDefault();

  const sectionData = JSON.parse(
    event.dataTransfer.getData("text/plain")
  );
  const dropZone = event.target.closest(".drop-zone");
  const position = dropZone.closest(".layout-position").dataset
    .position;
  const sectionsContainer = dropZone.querySelector(
    ".sections-container"
  );

  // Remove empty state
  const emptyState = sectionsContainer.querySelector(".empty-state");
  if (emptyState) {
    emptyState.remove();
  }

  // Create section element
  const sectionElement = createSectionElement(sectionData, position);
  sectionsContainer.appendChild(sectionElement);

  // Update layout data
  updateLayoutData();
  updateLayoutPreview();
}

function createSectionElement(sectionData, position) {
  const div = document.createElement("div");
  div.className =
    "layout-section bg-white border border-purple-200 rounded-lg p-3";
  div.dataset.sectionId = sectionData.Id;
  div.dataset.position = position;

  div.innerHTML = `
         <div class="flex items-center justify-between">
             <div class="flex items-center">
                 <i class="fas fa-grip-vertical text-slate-400 mr-2 cursor-move"></i>
                 <div>
                     <p class="text-sm font-medium text-slate-800">${sectionData.Name}</p>
                     <p class="text-xs text-slate-500">${sectionData.Type} - ${position}</p>
                 </div>
             </div>
            <div class="flex items-center space-x-2">
                <label class="flex items-center text-xs">
                    <input type="checkbox" class="required-checkbox mr-1" onchange="updateLayoutData()">
                    Required
                </label>
                <button type="button" onclick="removeSection(this)" class="text-red-600 hover:text-red-800">
                    <i class="fas fa-times"></i>
                </button>
            </div>
        </div>
    `;

  return div;
}

function removeSection(button) {
  const sectionElement = button.closest(".layout-section");
  const container = sectionElement.parentElement;

  sectionElement.remove();

  // Add empty state if no sections left
  if (container.children.length === 0) {
    container.innerHTML =
      '<div class="text-center text-slate-400 empty-state"><i class="fas fa-plus-circle text-2xl mb-2"></i><p class="text-sm">Drop sections here</p></div>';
  }

  updateLayoutData();
  updateLayoutPreview();
}

function updateLayoutData() {
  layoutSections = [];
  let sortOrder = 1;

  document.querySelectorAll(".layout-section").forEach((section) => {
    const sectionId = section.dataset.sectionId;
    const position = section.dataset.position;
    const isRequired = section.querySelector(
      ".required-checkbox"
    ).checked;

    layoutSections.push({
      SectionId: parseInt(sectionId),
      Position: position,
      SortOrder: sortOrder++,
      IsRequired: isRequired,
    });
  });
}

function updateLayoutSectionsData() {
  updateLayoutData();
  document.getElementById("layoutSectionsData").value =
    JSON.stringify(layoutSections);
}

function updateLayoutPreview() {
  const preview = document.getElementById("layoutPreview");

  if (layoutSections.length === 0) {
    preview.innerHTML = `
            <div class="text-center text-slate-400 py-8">
                <i class="fas fa-desktop text-4xl mb-2"></i>
                <p class="text-sm">Layout preview will appear here as you add sections</p>
            </div>
        `;
    return;
  }

  // Group sections by position
  const groupedSections = {};
  document.querySelectorAll(".layout-section").forEach((section) => {
    const position = section.dataset.position;
    const name = section.querySelector(
      ".text-sm.font-medium"
    ).textContent;
    const isRequired = section.querySelector(
      ".required-checkbox"
    ).checked;

    if (!groupedSections[position]) {
      groupedSections[position] = [];
    }
    groupedSections[position].push({ name, isRequired });
  });

  // Render preview
  const positions = ["header", "content", "sidebar", "footer"];
  preview.innerHTML = positions
    .map((position) => {
      if (!groupedSections[position]) return "";

      return `
            <div class="mb-3">
                <div class="bg-white border-2 border-dashed border-slate-300 rounded-lg p-3">
                    <div class="flex items-center justify-between mb-2">
                        <span class="text-xs font-medium text-slate-600 uppercase">${position}</span>
                        <span class="text-xs text-slate-500">${
                          groupedSections[position].length
                        } section(s)</span>
                    </div>
                    <div class="space-y-1">
                        ${groupedSections[position]
                          .map(
                            (section) => `
                            <div class="bg-purple-100 text-purple-800 px-2 py-1 rounded text-xs flex items-center justify-between">
                                <span>${section.name}</span>
                                ${
                                  section.isRequired
                                    ? '<i class="fas fa-exclamation-circle text-red-600" title="Required"></i>'
                                    : ""
                                }
                            </div>
                        `
                          )
                          .join("")}
                    </div>
                </div>
            </div>
        `;
    })
    .join("");
}

// Make functions globally available
window.loadAvailableSections = loadAvailableSections;
window.dragStart = dragStart;
window.allowDrop = allowDrop;
window.drop = drop;
window.removeSection = removeSection;
window.updateLayoutData = updateLayoutData;
window.updateLayoutSectionsData = updateLayoutSectionsData;
window.updateLayoutPreview = updateLayoutPreview;
