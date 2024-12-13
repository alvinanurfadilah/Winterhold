(() => {
    const url = "http://localhost:5155/api/v1/book/summary";

    let bindingBook = (book) => {
        let modal = document.querySelector(".modal");
        modal.style.display = "flex";

        let getSummary = document.querySelector("#summary");
        console.log(book);
        getSummary.textContent = book.summary;

        let getClose = document.querySelector(".close-category");
        getClose.addEventListener("click", (event) => {
            event.preventDefault();
            modal.style.display = "none";
        });
    };

    let summaryBook = (button) => {
        let row = button.parentElement.parentElement.parentElement;
        let getCode = row.querySelector("td:nth-child(2)").textContent;

        let request = new XMLHttpRequest();
        request.open("GET", `${url}?code=${getCode}`);
        request.send();
        request.onload = () => {
            let book = JSON.parse(request.response);
            bindingBook(book);
        };
    };

    let getSummary = () => {
        let buttonSummary = document.querySelectorAll(".summary");
        buttonSummary.forEach((book) => {
            book.addEventListener("click", (event) => {
                event.preventDefault();
                summaryBook(event.target);
            });
        });
    };

    let confirmDelete = () => {
        let getButton = document.querySelectorAll(".delete-book");
        getButton.forEach((book) => {
            book.addEventListener("click", () => {
                let confirm = window.confirm(
                    `Apakah anda yakin ingin menghapus buku ${book.getAttribute(
                        "value"
                    )}?`
                );
                if (confirm) {
                    window.location.href = category.closest("a").href;
                }
            });
        });
    };

    getSummary();
    summaryBook();

    confirmDelete();
})();
