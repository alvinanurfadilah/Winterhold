(() => {
    const url = "http://localhost:5155/api/v1/loan";

    //#region POST
    let insertLoan = () => {
        let modal = document.querySelector(".modal");
        modal.style.display = "flex";
        let getSubmit = document.querySelector(".update-loan");

        getSubmit.style.display = "none";

        let customerNumber = document.querySelector(".customer-dropdown").value;
        let bookCode = document.querySelector(".book-dropdown").value;
        let loanDate = document.querySelector(".loan-date").value;
        let note = document.querySelector(".note").value;

        let getClose = document.querySelector(".close-loan");
        getClose.addEventListener("click", (event) => {
            event.preventDefault();
            modal.style.display = "none";
        });

        return { customerNumber, bookCode, loanDate, note };
    };

    let sendLoan = () => {
        let request = new XMLHttpRequest();
        request.open("POST", url);
        request.setRequestHeader("Content-Type", "application/json");
        request.send(JSON.stringify(insertLoan()));
        request.onload = () => {
            console.log(request.response);
            location.reload();
        };
    };

    let getDropdown = () => {
        let request = new XMLHttpRequest();
        request.open("GET", url);
        request.onload = () => {
            let data = JSON.parse(request.response);
            let customers = data.customers;
            let books = data.books;

            let selectCustomer = document.querySelector(".customer-dropdown");
            let selectBook = document.querySelector(".book-dropdown");

            customers.forEach((customer) => {
                let option = new Option(customer.text, customer.value);
                selectCustomer.options.add(option);
            });

            books.forEach((book) => {
                let option = new Option(book.text, book.value);
                selectBook.options.add(option);
            });
        };
        request.send();
    };

    let submit = () => {
        let getSubmit = document.querySelector(".insert-loan");
        getSubmit.addEventListener("click", (event) => {
            event.preventDefault();
            sendLoan();
        });
    };

    let getAddNewLoan = () => {
        let button = document.querySelector(".add");
        button.addEventListener("click", () => {
            insertLoan();
        });
    };
    //#endregion

    //#region PUT
    let loanId;
    let updateLoan = () => {
        let customerNumber = document.querySelector(".customer-dropdown").value;
        let bookCode = document.querySelector(".book-dropdown").value;
        let loanDate = document.querySelector(".loan-date").value;
        let note = document.querySelector(".note").value;

        let customers = [];
        let books = [];
        let id = loanId;

        let modal = document.querySelector(".modal");
        let getClose = document.querySelector(".close-loan");
        getClose.addEventListener("click", (event) => {
            event.preventDefault();
            modal.style.display = "none";
        });

        console.log(customerNumber);
        console.log(bookCode);
        console.log(loanDate);
        console.log(note);

        return { id, customerNumber, bookCode, loanDate, note, customers, books };
    };

    let sendLoanUpdate = () => {
        let request = new XMLHttpRequest();
        request.open("PUT", `${url}`);
        request.setRequestHeader("Content-Type", "application/json");
        request.send(JSON.stringify(updateLoan()));
        request.onload = () => {
            location.reload();
        };
    };

    let submitUpdate = () => {
        let button = document.querySelector(".update-loan");
        button.addEventListener("click", (event) => {
            event.preventDefault();
            sendLoanUpdate();
        });
    };

    let bindingLoan = (loan) => {
        console.log(loan.customerNumber);
        console.log(loan.bookCode);
        console.log(loan.loanDate);
        console.log(loan.note);
        let modal = document.querySelector(".modal");
        modal.style.display = "flex";
        let getSubmit = document.querySelector(".insert-loan");
        getSubmit.style.display = "none";

        let customerNumber = document.querySelector(".customer-dropdown");
        let bookCode = document.querySelector(".book-dropdown");
        let loanDate = document.querySelector(".loan-date");
        let note = document.querySelector(".note");
        let getLoanDate = loan.loanDate.toString();

        customerNumber.value = loan.customerNumber;
        bookCode.value = loan.bookCode;
        loanDate.value = getLoanDate.split('T')[0];
        note.value = loan.note;
    };

    let getLoan = (id) => {
        let request = new XMLHttpRequest();
        request.open("GET", `${url}/${id}`);
        request.send();
        request.onload = () => {
            let loan = JSON.parse(request.response);
            console.log(loan);
            loanId = id;
            bindingLoan(loan);
        };
    };

    let getUpdateLoan = () => {
        let getButton = document.querySelectorAll(".edit-loan");
        getButton.forEach((loan) => {
            loan.addEventListener("click", (event) => {
                event.preventDefault();
                getLoan(loan.getAttribute("value"));
            });
        });
    };
    //#endregion

    //#region Detail
    let bindingDetail = (detail) => {
        let modal = document.querySelector(".modal-detail");
        modal.style.display = "flex";

        let title = document.querySelector("#title");
        let category = document.querySelector("#category");
        let author = document.querySelector("#author");
        let floor = document.querySelector("#floor");
        let isle = document.querySelector("#isle");
        let bay = document.querySelector("#bay");

        let membershipNumber = document.querySelector("#membership-number");
        let fullname = document.querySelector("#full-name");
        let phone = document.querySelector("#phone");
        let expireDate = document.querySelector("#expire-date");

        title.textContent = detail.title;
        category.textContent = detail.categoryName;
        author.textContent = detail.author;
        floor.textContent = detail.floor;
        isle.textContent = detail.isle;
        bay.textContent = detail.bay;

        membershipNumber.textContent = detail.membershipNumber;
        fullname.textContent = detail.fullName;
        phone.textContent = detail.phone;
        expireDate.textContent = detail.membershipExpireDate;

        let getClose = document.querySelector(".close-loan");
        getClose.addEventListener("click", (event) => {
            event.preventDefault();
            modal.style.display = "none";
        });
    };

    let detailLoan = (button) => {
        let row = button.parentElement.parentElement.parentElement;
        let getId = row.querySelector("td:nth-child(2)").textContent;

        let request = new XMLHttpRequest();
        request.open("GET", `${url}/detail/${getId}`);
        request.send();
        request.onload = () => {
            let detailLoan = JSON.parse(request.response);
            bindingDetail(detailLoan);
        };
    };

    let getButtonDetail = () => {
        let buttonDetail = document.querySelectorAll(".detail-loan");
        buttonDetail.forEach((detail) => {
            detail.addEventListener("click", (event) => {
                event.preventDefault();
                detailLoan(event.target);
            });
        });
    };

    //#endregion
    getButtonDetail();
    getAddNewLoan();
    submit();
    getDropdown();

    getUpdateLoan();
    submitUpdate();
})();
