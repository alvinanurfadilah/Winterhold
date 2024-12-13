(() => {
    const url = 'http://localhost:5155/api/v1/customer'

    let bindingCustomer = (customer) => {
        let modal = document.querySelector('.modal');
        modal.style.display = 'flex';

        let membershipNumber = document.querySelector('#membership-number');
        let fullName = document.querySelector('#full-name');
        let birthDate = document.querySelector('#birth-date');
        let gender = document.querySelector('#gender');
        let phone = document.querySelector('#phone');
        let address = document.querySelector('#address');

        membershipNumber.textContent = customer.membershipNumber;
        fullName.textContent = customer.fullName;
        birthDate.textContent = customer.birthDate;
        gender.textContent = customer.gender;
        phone.textContent = customer.phone;
        address.textContent = customer.address;

        let getClose = document.querySelector('.close-category');
        getClose.addEventListener('click', (event) => {
            event.preventDefault();
            modal.style.display = 'none';
        });
    }

    let detailCustomer = (button) => {
        let row = button.parentElement.parentElement;
        let getMembership = row.querySelector('td:nth-child(2)').textContent;
        
        let request = new XMLHttpRequest();
        request.open('GET', `${url}?membershipNumber=${getMembership}`);
        request.send();
        request.onload = () => {
            let customer = JSON.parse(request.response);
            bindingCustomer(customer);
        }
    }

    let getButtonDetail = () => {
        let buttonDetail = document.querySelectorAll('.membership');
        buttonDetail.forEach(detail => {
            detail.addEventListener('click', (event) => {
                event.preventDefault();
                detailCustomer(event.target);
            })
        })
    }

    getButtonDetail();
})();