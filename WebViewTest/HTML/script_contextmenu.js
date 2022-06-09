const contextMenu = document.getElementById("context-menu");
const scope = document.querySelector("body");

var test = document.getElementsByTagName("table")
var curretFocusedTable = test[0]


for (let index = 0; index < test.length; index++) {
    const scope = test[index];
    const normalizePozition = (mouseX, mouseY) => {
        // ? compute what is the mouse position relative to the container element (scope)
        let {
            left: scopeOffsetX,
            top: scopeOffsetY,
        } = scope.getBoundingClientRect();

        scopeOffsetX = scopeOffsetX < 0 ? 0 : scopeOffsetX;
        scopeOffsetY = scopeOffsetY < 0 ? 0 : scopeOffsetY;

        const scopeX = mouseX - scopeOffsetX;
        const scopeY = mouseY - scopeOffsetY;

        // ? check if the element will go out of bounds
        const outOfBoundsOnX =
            scopeX + contextMenu.clientWidth > scope.clientWidth;

        const outOfBoundsOnY =
            scopeY + contextMenu.clientHeight > scope.clientHeight;

        let normalizedX = mouseX;
        let normalizedY = mouseY;

        // ? normalize on X
        if (outOfBoundsOnX) {
            normalizedX =
                scopeOffsetX + scope.clientWidth - contextMenu.clientWidth;
        }

        // ? normalize on Y
        if (outOfBoundsOnY) {
            normalizedY =
                scopeOffsetY + scope.clientHeight - contextMenu.clientHeight;
        }

        return { normalizedX, normalizedY };
    };

    scope.addEventListener("contextmenu", (event) => {
        event.preventDefault();

        curretFocusedTable = event.currentTarget

        const { clientX: mouseX, clientY: mouseY } = event;

        const { normalizedX, normalizedY } = normalizePozition(mouseX, mouseY);

        contextMenu.classList.remove("visible");

        contextMenu.style.top = `${normalizedY}px`;
        contextMenu.style.left = `${normalizedX}px`;

        setTimeout(() => {
            contextMenu.classList.add("visible");
        });
    });

    scope.addEventListener("click", (e) => {
        // ? close the menu if the user clicks outside of it
        if (e.target.offsetParent != contextMenu) {
            contextMenu.classList.remove("visible");
        }
    });



}
function addRows(){
    table = curretFocusedTable;
	//var table = document.getElementById(.id);
	var rowCount = table.rows.length;
	var cellCount = table.rows[0].cells.length; 
	var row = table.insertRow(rowCount);
    
    for (let index = 0; index < cellCount; index++) {
        var cell = row.insertCell("test"+index)
        cell.innerHTML = "test" + index
    }

    contextMenu.classList.remove("visible");

}
function deleteRows(){
	var table = document.getElementById('emptbl');
	var rowCount = table.rows.length;
	if(rowCount > '2'){
		var row = table.deleteRow(rowCount-1);
		rowCount--;
	}
	else{
		alert('There should be atleast one row');
	}

    contextMenu.classList.remove("visible");
}
