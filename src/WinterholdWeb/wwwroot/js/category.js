(() => {
    const url = "http://localhost:5155/api/v1/category";

    //#region PUT
    let updateCategory = () => {
        let name = document.querySelector("#category-name").value;
        let floor = document.querySelector("#floor").value;
        let isle = document.querySelector("#isle").value;
        let bay = document.querySelector("#bay").value;

        let modal = document.querySelector(".modal");
        let getClose = document.querySelector(".close-category");
        getClose.addEventListener("click", (event) => {
            event.preventDefault();
            modal.style.display = "none";
        });

        return { name, floor, isle, bay };
    };

    let sendCategoryUpdate = () => {
        let request = new XMLHttpRequest();
        request.open("PUT", `${url}`);
        request.setRequestHeader("Content-Type", "application/json");
        request.send(JSON.stringify(updateCategory()));
        request.onload = () => {
            console.log(request.response);
            location.reload();
        };
    };

    let submitUpdate = () => {
        let button = document.querySelector(".update-category");
        button.addEventListener("click", (event) => {
            event.preventDefault();
            sendCategoryUpdate();
        });
    };

    let bindingCategory = (category) => {
        let modal = document.querySelector(".modal");
        modal.style.display = "flex";
        let getSubmit = document.querySelector(".insert-category");
        getSubmit.style.display = "none";

        let getName = document.querySelector("#category-name");
        let getFloor = document.querySelector("#floor");
        let getIsle = document.querySelector("#isle");
        let getBay = document.querySelector("#bay");

        getName.value = category.name;
        getFloor.value = category.floor;
        getIsle.value = category.isle;
        getBay.value = category.bay;
    };

    let getCategory = (categoryName) => {
        let request = new XMLHttpRequest();
        request.open("GET", `${url}?name=${categoryName}`);
        request.send();
        request.onload = () => {
            let category = JSON.parse(request.response);

            bindingCategory(category);
        };
    };

    let getUpdateCategory = () => {
        let getButtons = document.querySelectorAll(".category-edit");
        getButtons.forEach((category) => {
            category.addEventListener("click", (event) => {
                event.preventDefault();
                getCategory(category.getAttribute("value"));
            });
        });
    };
    //#endregion

    //#region POST
    let insertCategory = () => {
        let modal = document.querySelector(".modal");
        modal.style.display = "flex";
        let getSubmit = document.querySelector(".update-category");
        getSubmit.style.display = "none";

        let name = document.querySelector("#category-name").value;
        let floor = document.querySelector("#floor").value;
        let isle = document.querySelector("#isle").value;
        let bay = document.querySelector("#bay").value;

        let getClose = document.querySelector(".close-category");
        getClose.addEventListener("click", (event) => {
            event.preventDefault();
            modal.style.display = "none";
        });

        return { name, floor, isle, bay };
    };

    let sendCategory = () => {
        let request = new XMLHttpRequest();
        request.open("POST", url);
        request.setRequestHeader("Content-Type", "application/json");
        request.send(JSON.stringify(insertCategory()));
        request.onload = () => {
            console.log(request.response);
            let modal = document.querySelector(".modal");
            modal.style.display = "none";
            location.reload();
        };
    };

    let submit = () => {
        let getSubmit = document.querySelector(".insert-category");
        getSubmit.addEventListener("click", (event) => {
            event.preventDefault();
            sendCategory();
        });
    };

    let getAddNewCategory = () => {
        let button = document.querySelector(".add");
        button.addEventListener("click", () => {
            insertCategory();
        });
    };
    //#endregion

    //#region Delete
    let getDeleteCategory = () => {
        let button = document.querySelectorAll(".category-delete");
        button.forEach((category) => {
            category.addEventListener("click", (event) => {
                event.preventDefault();
                let confirm = window.confirm(
                    `Apakah anda yakin ingin menghapus ${category.getAttribute(
                        "value"
                    )}?`
                );
                if (confirm) {
                    window.location.href = category.closest('a').href;
                }
            });
        });
    };

    getUpdateCategory();
    submitUpdate();
    getAddNewCategory();
    submit();

    getDeleteCategory();
})();
