// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl)
})

function deleteElementById(item) {
    if (item.previousElementSibling || item.nextElementSibling) {
        document.getElementById(item.id).remove();
    }
    else {
        alert("The last element cannot be deleted");
    }
}

function addLessonItemToAccordion(accordion) {
    var newItemObj = createNewAccordionItem(accordion);
    var collapsedDiv = newItemObj.newItem.querySelector(".accordion-collapse", ".collapse");
    var textarea = collapsedDiv.querySelector("textarea");
    var regExp = new RegExp("\\d+");
    textarea.name = textarea.name.replace(regExp, newItemObj.newId);
    console.log(textarea);
    textarea.innerHTML = "";
    textarea.value = "";
    accordion.appendChild(newItemObj.newItem);
}

function addQuestionItemToAccordion(accordion) {
    var newItemObj = createNewAccordionItem(accordion);
    var newItem = newItemObj.newItem;
    var regExp = new RegExp("\\d+");
    var addButton = newItem.querySelector(".btn-add");
    addButton.setAttribute("onclick", addButton.getAttribute("onclick").replace(regExp, newItemObj.newId));
    var itemList = newItem.querySelector("ul");
    itemList.id = itemList.id.replace(regExp, newItemObj.newId);
    var newListItem = itemList.lastElementChild.cloneNode(true);
    var child = itemList.lastElementChild;
    while (child) {
        itemList.removeChild(child);
        child = itemList.lastElementChild;
    }
    newListItem = editListItemElement(newListItem, 1, newItemObj.newId);
    itemList.appendChild(newListItem);
    accordion.appendChild(newItem);
}

function createNewAccordionItem(accordion) {
    var accordionLastItem = accordion.lastElementChild;
    var newItem = accordionLastItem.cloneNode(true);
    var regExp = new RegExp("\\d+");
    var lastQuestionNumber = regExp.exec(accordionLastItem.id)[0];
    var newId = parseInt(lastQuestionNumber, 10) + 1;
    newItem.id = newItem.id.replace(regExp, newId);
    var itemHeaderDiv = newItem.querySelector(".accordion-item-header");
    itemHeaderDiv.id = itemHeaderDiv.id.replace(regExp, newId);
    var headerInput = itemHeaderDiv.querySelector("input");
    headerInput.id = headerInput.id.replace(regExp, newId);
    headerInput.removeAttribute("value");
    headerInput.value = "";
    var headerInputLabel = itemHeaderDiv.querySelector("label");
    headerInputLabel.setAttribute("for", headerInput.id);
    headerInputLabel.innerHTML = headerInputLabel.innerHTML.replace(regExp, newId);
    var collapseButton = newItem.querySelector(".accordion-button");
    var attribute = collapseButton.getAttribute("data-bs-target");
    collapseButton.setAttribute("data-bs-target", attribute.replace(regExp, newId));
    attribute = collapseButton.getAttribute("aria-controls");
    collapseButton.setAttribute("aria-controls", attribute.replace(regExp, newId));
    var closeButton = newItem.querySelector(".btn-close", ".btn-delete");
    attribute = closeButton.getAttribute("onclick");
    closeButton.setAttribute("onclick", attribute.replace(regExp, newId));
    var collapsedDiv = newItem.querySelector(".accordion-collapse", ".collapse");
    collapsedDiv.id = collapsedDiv.id.replace(regExp, newId);
    attribute = collapsedDiv.getAttribute("aria-labelledby");
    collapsedDiv.setAttribute("aria-labelledby", attribute.replace(regExp, newId));
    return { newItem, newId };
}

function addAnswerItemToList(answersList) {
    var answersListLastItem = answersList.lastElementChild;
    var newItem = answersListLastItem.cloneNode(true);
    var regExp = new RegExp("\\d+");
    var newItemId = parseInt(regExp.exec(answersListLastItem.id)[0], 10) + 1;
    newItem = editListItemElement(newItem, newItemId);
    answersList.appendChild(newItem);
}

function editListItemElement(element, newIndex, newListIndex) {
    var regExpOnMid = new RegExp("\\d+");
    var regExpOnEnd = new RegExp("\\d+$");
    var regExpInBrackets = new RegExp("(?<=\\W)\\w+(?=\\W)");
    element.id = element.id.replace(regExpOnMid, newIndex);
    if (newListIndex) {
        element.id = element.id.replace(regExpOnEnd, newListIndex);
    }
    var answerInput = element.querySelector(".form-control");
    answerInput.id = answerInput.id.replace(regExpOnMid, newIndex);
    if (newListIndex) {
        answerInput.id = answerInput.id.replace(regExpOnEnd, newListIndex);
        answerInput.setAttribute("name", answerInput.getAttribute("name").replace(regExpOnEnd, newListIndex));
    }
    answerInput.removeAttribute("value");
    answerInput.value = "";
    var answerLabel = answerInput.nextElementSibling;
    answerLabel.setAttribute("for", answerInput.id);
    answerLabel.innerHTML = answerLabel.innerHTML.replace(regExpOnMid, newIndex);
    var checkBox = element.querySelector(".form-check-input");
    checkBox.id = checkBox.id.replace(regExpOnMid, newIndex);
    if (newListIndex) {
        checkBox.id = checkBox.id.replace(regExpOnEnd, newListIndex);
        checkBox.setAttribute("name", checkBox.getAttribute("name").replace(regExpOnEnd, newListIndex));
    }

    checkBox.setAttribute("value", newIndex);
    var closeButton = element.querySelector(".btn-close", ".btn-delete");
    closeButton.setAttribute("onclick", closeButton.getAttribute("onclick").replace(regExpInBrackets, element.id));
    return element;
}