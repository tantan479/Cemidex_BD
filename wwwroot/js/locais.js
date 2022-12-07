const container = document.querySelector(".containerlocal");
const covas = document.querySelectorAll(".row .cova:not(.indis)");
const count = document.getElementById("count");
const total = document.getElementById("total");
const areaSelect = document.getElementById("area");

populateUI();

let Price = +areaSelect.value;

// Save selected area index and price
function setareaData(areaIndex, areaPrice) {
    localStorage.setItem("selectedareaIndex", areaIndex);
    localStorage.setItem("selectedareaPrice", areaPrice);
}

// Update total and count
function updateSelectedCount() {
    const selectedcovas = document.querySelectorAll(".row .cova.selected");

    const covasIndex = [...selectedcovas].map((cova) => [...covas].indexOf(cova));

    localStorage.setItem("selectedcovas", JSON.stringify(covasIndex));

    const selectedcovasCount = selectedcovas.length;

    count.innerText = selectedcovasCount;
    total.innerText = selectedcovasCount * Price;

    setareaData(areaSelect.selectedIndex, areaSelect.value);
}


// Get data from localstorage and populate UI
function populateUI() {
    const selectedcovas = JSON.parse(localStorage.getItem("selectedcovas"));

    if (selectedcovas !== null && selectedcovas.length > 0) {
        covas.forEach((cova, index) => {
            if (selectedcovas.indexOf(index) > -1) {
                console.log(cova.classList.add("selected"));
            }
        });
    }

    const selectedareaIndex = localStorage.getItem("selectedareaIndex");

    if (selectedareaIndex !== null) {
        areaSelect.selectedIndex = selectedareaIndex;
        console.log(selectedareaIndex)
    }
}
console.log(populateUI())
// area select event
areaSelect.addEventListener("change", (e) => {
    Price = +e.target.value;
    setareaData(e.target.selectedIndex, e.target.value);
    updateSelectedCount();
});

// cova click event
container.addEventListener("click", (e) => {
    if (
        e.target.classList.contains("cova") &&
        !e.target.classList.contains("indis")
    ) {
        e.target.classList.toggle("selected");

        updateSelectedCount();
    }
});

// Initial count and total set
updateSelectedCount();
