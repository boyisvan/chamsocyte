<template>
    <div class="form-control content">
        <div class="mt-2 datlich" style="font-family: 'Signika Negative', cursive;">
            <h2 class="text-center ">Đặt Lịch Khám Bệnh</h2>
            <form id="appointmentForm">
                <div class="mb-1">
                    <label for="fullName" class="form-label">Họ và Tên</label>
                    <input type="text" class="form-control" id="fullName" required>
                </div>
                <div class="mb-1">
                    <label for="gender" class="form-label">Giới Tính</label>
                    <select class="form-select" id="gender" required>
                        <option value="" disabled selected>-- Chọn giới tính --</option>
                        <option value="Nam">Nam</option>
                        <option value="Nữ">Nữ</option>
                    </select>
                </div>
                <div class="mb-1">
                    <label for="age" class="form-label">Tuổi</label>
                    <input type="number" class="form-control" id="age" required>
                </div>
                <div class="mb-1">
                    <label for="symptoms" class="form-label">Vấn đề của bạn (hoặc tiền sử bệnh)</label>
                    <textarea class="form-control" id="symptoms" rows="3" required></textarea>
                </div>
                <div class="mb-4">
                    <label for="appointmentDate" class="form-label">Ngày Yêu Cầu Khám Bệnh</label>
                    <input type="date" class="form-control" id="appointmentDate" required>
                </div>
                <div class="text-center mb-5">
                    <button type="button" class=" btn btn-primary" @click="submitForm">Đặt Lịch Khám Bệnh</button>
                </div>
            </form>
        </div>
        <div class="qrchuyentien">
            <div class="qrcode" id="imgBox">
                <img id="qrImage" src="">
                <br>
            </div>
            <p>
                Quét mã để nhận thông tin của bạn</p>
        </div>
    </div>
</template>

<script>
import Swal from 'sweetalert2';
export default {
    data() {
        return {
        }
    },
    methods: {
        submitForm() {
            // Lấy giá trị từ các trường nhập
            var fullName = document.getElementById('fullName').value;
            var gender = document.getElementById('gender').value;
            var age = document.getElementById('age').value;
            var symptoms = document.getElementById('symptoms').value;
            var appointmentDate = document.getElementById('appointmentDate').value;


            if (fullName == "" || gender == "" || age == "" || symptoms == "" || appointmentDate == "") {
                Swal.fire({
                    icon: "error",
                    title: "Oops...",
                    text: "Bạn chưa nhập đủ thông tin",
                });
            }
            else {
                // Hiển thị thông báo
                var message = "Họ và tên: " + fullName + " , ";
                message += "Giới tính: " + gender + " , ";
                message += "Tuổi: " + age + " , ";
                message += "Triệu chứng: " + symptoms + " , ";
                message += "Ngày yêu cầu khám bệnh: " + appointmentDate;


                Swal.fire({
                    title: "Xác nhận lại thông tin?",
                    text: message,
                    icon: "success",
                    showCancelButton: true,
                    confirmButtonColor: "#3085d6",
                    cancelButtonColor: "#d33",
                    confirmButtonText: "Gửi!"
                }).then((result) => {
                    if (result.isConfirmed) {
                        Swal.fire({
                            title: "Thành công !",
                            text: " Thông tin của bạn đã được lưu lại !",
                            icon: "success"
                        });
                    }
                });


                const qrContent = "Họ tên khách hàng : " + fullName
                    + "\n Giới tính : " + gender
                    + "\n Tuổi : " + age
                    + "Triệu chứng bệnh : " + symptoms
                    + "Ngày khám : " + appointmentDate;
                let imgBox = document.getElementById("imgBox");
                let qrImage = document.getElementById("qrImage");
                // Sử dụng thư viện "qrcode-svg" để tạo hình ảnh QR code
                qrImage.src = " https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=" + qrContent;
            }
        },
    }
};
</script>



<style>
.content {
    display: flex;
    justify-content: space-around;
    align-items: center;
    margin-bottom: 30px;
}

.datlich {
    flex-basis: 50%;
}

.qrchuyentien {
    display: flex;
    justify-content: center;
    align-items: center;
    flex-basis: 50%;
    flex-direction: column;

}

.qrcode {
    margin-bottom: 14px;
    padding: 7px;
    /* border: 1px solid black; */
}

@media (max-width:700px) and (min-width:300px) {
    .content {
        flex-direction: column;
    }

    .datlich {
        width: 100%;
    }
}
</style>