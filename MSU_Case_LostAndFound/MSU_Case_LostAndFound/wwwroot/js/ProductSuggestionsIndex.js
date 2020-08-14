// Send an Ajax request to GET product suggestions like a search string, and display the results in targetElement.
function getProductSuggestionLike(targetElement, partialName) {

    // Empty the target list element on the web page.
    $(targetElement).empty();

    // If the user didn't enter anything in the text box, return immediately.
    var value = $(partialName).val();
    if (value === "")
        return;

    // Send an Ajax request to GET product suggestions like a search string, and process the results.
    var theUrl = "/api/productsuggestions/?partialName=" + value;
    $.ajax({
        type: "GET",
        url: theUrl,
        cache: false,

        accepts: {
            json: 'application/json'
        },

        success: function (productSuggestionsData, status, xhr) {
            $.each(productSuggestionsData, function (key, productSuggestion) {
                displayProductSuggestion(targetElement, productSuggestion);
            });
        },

        error: function (xhr, message, errorThrown) {
            displayError(xhr, message, errorThrown);
        }
    });
}



// Helper function, to display one ProductSuggestion object as an <li> element in the specified target list element.
function displayProductSuggestion(targetElement, productSuggestion) {
    $(targetElement).append("<li>[" + productSuggestion.id + "] "
                                    + productSuggestion.name + ", "
                                    + productSuggestion.lost + ", ");
}


// Helper function, to display an error message.
function displayError(xhr, message, errorThrown) {
    if (xhr.status === 404) {
        alert("Item not found");
    }
    else {
        alert("Ajax error occurred: " + errorThrown);
    }
}