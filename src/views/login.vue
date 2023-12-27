<template>
    <button type="button" class="btn btn-outline-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
        Login admin page
    </button>

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Đăng nhập với tư cách quản trị</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <form @submit.prevent="submitForm">
                    <div class="modal-body">
                        <label for="username">Tên đăng nhập:</label>
                        <input class="form-control " v-model="username" type="text" id="username" required>

                        <label for="password">Mật khẩu:</label>
                        <input class="form-control " v-model="password" type="password" id="password" required>

                    </div>
                    <div class="modal-footer">
                        <button type="submit" class="btn btn-primary" data-bs-dismiss="modal">Đăng nhập</button>
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Đóng</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
import { RouterLink, RouterView } from 'vue-router';
import Swal from 'sweetalert2';
export default {
    data() {
        return {
            username: "",
            password: ""
        };
    },
    methods: {
        submitForm() {
            if (this.username === "admin" && this.password === "123456") {
                // Nếu tên đăng nhập và mật khẩu đúng, chuyển hướng đến trang admin
                this.$router.push({ name: 'admin' })

            } else {
                // Hiển thị thông báo lỗi
                Swal.fire({
                    title: "opps",
                    text: 'Sai tên đăng nhập hoặc mật khẩu !!',
                    icon: 'warning',
                })
            }
        }
    }
};
</script>