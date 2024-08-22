function showToast(message, type) {

    var toastTypeClass;
    if (type === 'success') {
        toastTypeClass = 'bg-success text-white';
    } else if (type === 'danger') {
        toastTypeClass = 'bg-danger text-white';
    } else {
        toastTypeClass = 'bg-secondary text-white';
    }

    var toastHTML = `
        <div class="toast align-items-center ${toastTypeClass} border-0" role="alert" aria-live="assertive" aria-atomic="true">
            <div class="d-flex">
                <div class="toast-body">
                    ${message}
                </div>
                <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
        </div>
    `;

    var toastContainer = document.createElement('div');
    toastContainer.className = 'toast-container position-fixed top-0 end-0 p-3';  
    toastContainer.innerHTML = toastHTML;
    document.body.appendChild(toastContainer);

    var toastElement = toastContainer.querySelector('.toast');
    var toast = new bootstrap.Toast(toastElement);
    toast.show();

    toastElement.addEventListener('hidden.bs.toast', function () {
        toastContainer.remove();
    });
}
