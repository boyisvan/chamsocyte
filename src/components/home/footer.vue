<template>
    <div style="width: 100%;">
        <img v-if="isDesktop" style="width: 100%;" src="@/assets/photo/bannerwweb1.jpg" alt="">
        <img v-else style="width: 100%;" src="@/assets/photo/bannermobile1.jpg" alt="">
    </div>
    <footer class="bg-dark text-center text-white">
        <!-- Grid container -->
        <div class="container p-4 pb-0">
            <!-- Section: Form -->
            <section class="">
                <!-- <form> -->
                <!--Grid row-->
                <div class="row d-flex justify-content-center">
                    <!--Grid column-->
                    <div class="col-auto">
                        <p class="pt-2">
                            <strong>Để lại thông tin nhận khuyến mại :</strong>
                        </p>
                    </div>
                    <div class="col-md-5 col-12">
                        <div class="form-outline form-white mb-4">
                            <input type="text" v-model="soDienThoai" id="email code" class="form-control input"
                                placeholder="Số điện thoại hoặc email" />
                        </div>
                    </div>
                    <div class="col-auto">
                        <button type="" class="btn btn1 btn-outline-light mb-4" @click="copyData(data.soDienThoai)">
                            Gửi
                        </button>
                    </div>
                </div>
                <!-- </form> -->
            </section>
        </div>
        <!-- Copyright -->
        <div class="text-center p-3" style="background-color: rgba(0, 0, 0, 0.2);">
            © 05/11/2023 Copyright:
            <a class="text-white" href="#">Hoang Duc Van Coder - 0587282880</a>
        </div>
        <!-- Copyright -->
    </footer>
</template>


<style>
footer {
    font-size: 12px;
}

strong {
    font-size: 12px;
}

.input,
.btn1 {
    font-size: 12px;
}
</style>


<script>
import axios from 'axios';
import Swal from 'sweetalert2';
// import QRCode from "qrcode-svg";
export default {
    props: {
    },
    data() {
        return {
            data: [],
            soDienThoai: null,
            isDesktop: false,
        }
    },
    mounted() {
        // Gọi hàm để xử lý trạng thái hiển thị ảnh dựa trên chiều rộng màn hình khi component được mounted
        this.handleResize();

        // Thêm sự kiện resize để xử lý khi kích thước màn hình thay đổi
        window.addEventListener('resize', this.handleResize);
    },
    methods: {
        copyData(soDienThoai) {
            // const message = "Code sẽ được gửi tới " + this.soDienThoai + " sớm nhất , hãy kiểm tra";
            var message = "Chúng tôi sẽ liên hệ với bạn qua thông tin " + this.soDienThoai + " sớm nhất"
            Swal.fire(message);
            Swal.fire({
                title: "Thành",
                text: message,
                icon: "success"
            });
        },

        handleResize() {
            // Cập nhật trạng thái hiển thị ảnh dựa trên chiều rộng màn hình
            this.isDesktop = window.innerWidth >= 800;
        },
        beforeDestroy() {
            // Gỡ bỏ sự kiện resize khi component bị hủy
            window.removeEventListener('resize', this.handleResize);
        }
    },
}
</script>