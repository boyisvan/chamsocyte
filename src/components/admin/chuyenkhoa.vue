<template>
    <div>
        <h4>Trang quản lí chuyên khoa</h4>
        <div class="databacsi">

            <button class="btn btn-success  m-2 fload-end" data-bs-toggle="modal" data-bs-target="#themchuyenkhoa"
                @click="addClick()">Thêm chuyên khoa</button>

            <table class="table table-bordered table-hover text-center align-items-center  ">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Tên</th>
                        <th>Thao tác</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="chuyenkhoa in chuyenkhoa" :key="chuyenkhoa.idChuyenKhoa">
                        <td>{{ chuyenkhoa.idChuyenKhoa }}</td>
                        <td>{{ chuyenkhoa.tenChuyenKhoa }}</td>
                        <td>
                            <button class="btn btn-outline-warning  btn-sm " data-bs-toggle="modal"
                                data-bs-target="#themchuyenkhoa" @click="editClick(chuyenkhoa)">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                                    class="bi bi-pencil-square" viewBox="0 0 16 16">
                                    <path
                                        d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                    <path fill-rule="evenodd"
                                        d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
                                </svg>
                            </button> |
                            <button class="btn btn-outline-danger btn-sm " @click="deleteClick(chuyenkhoa.idChuyenKhoa)">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                                    class="bi bi-trash" viewBox="0 0 16 16">
                                    <path
                                        d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5Zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5Zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6Z" />
                                    <path
                                        d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1ZM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118ZM2.5 3h11V2h-11v1Z" />
                                </svg>
                            </button>
                        </td>
                    </tr>
                </tbody>
            </table>

            <div class="modal fade" id="themchuyenkhoa" tabindex="-1" aria-labelledby="themchuyenkhoalabel"
                aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered ">
                    <div class="modal-content ">
                        <div class="modal-header ">
                            <h5 class="modal-title " id="themchuyenkhoalabel">{{ modalTitle }}</h5>
                            <button class="btn-close " data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <div class="input-group mb-3">
                                <span class="input-group-text ">Tên Chuyên Khoa</span>
                                <input type="text" class="form-control " v-model="tenChuyenKhoa">
                            </div>
                            <button v-if="idChuyenKhoa == 0" class="btn btn-primary" @click="createClick()"
                                data-bs-dismiss="modal">Thêm
                                mới</button>
                            <button v-if="idChuyenKhoa != 0" class="btn btn-primary " @click="updateClick()"
                                data-bs-dismiss="modal">Cập
                                nhật</button>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</template>

<script>
import axios from 'axios';
import configURL from '@/configURL';
import Swal from 'sweetalert2';
export default {
    data() {
        return {
            chuyenkhoa: [],
            modalTitle: "",
            idChuyenKhoa: 0,
            tenChuyenKhoa: "",
        }
    },
    methods: {
        getData() {
            axios.get(configURL.chuyenkhoaURL).then((response) => {
                this.chuyenkhoa = response.data;
            });
        },
        addClick() {
            this.modalTitle = "Thêm chuyên khoa";
            this.idChuyenKhoa = 0;
            this.tenChuyenKhoa = "";
        },
        editClick(chuyenkhoa) {
            this.modalTitle = "Sửa thông tin chuyên khoa";
            this.idChuyenKhoa = chuyenkhoa.idChuyenKhoa;
            this.tenChuyenKhoa = chuyenkhoa.tenChuyenKhoa;
        },
        createClick() {
            axios.post(configURL.chuyenkhoaURL, {
                tenChuyenKhoa: this.tenChuyenKhoa,
            }).then((response) => {
                this.getData();
                Swal.fire({
                    title: 'Thêm thành công !',
                    icon: 'success',
                    text: response.data,
                })
            });
        },
        updateClick() {
            axios.put(configURL.chuyenkhoaURL, {
                idChuyenKhoa: this.idChuyenKhoa,
                tenChuyenKhoa: this.tenChuyenKhoa,
            }).then((response) => {
                this.getData();
                Swal.fire({
                    title: 'Cập nhật thành công !',
                    icon: 'success',
                    text: response.data,
                })
            });
        },
        deleteClick(id) {
            Swal.fire({
                title: "Bạn có chắc muốn xóa?",
                text: "Dữ liệu sẽ bị mất vĩnh viễn",
                icon: "warning",
                showCancelButton: true,
                confirmButtonColor: "#3085d6",
                cancelButtonColor: "#d33",
                confirmButtonText: "Vâng, chắc chắn xóa!"
            }).then((result) => {
                if (result.isConfirmed) {
                    axios.delete(configURL.chuyenkhoaURL + "/" + id).then((response) => {
                        this.getData();
                        Swal.fire({
                            title: "Đã xóa!",
                            text: response.data,
                            icon: "success"
                        });
                    });
                }
            });
        }
    },
    mounted: function () {
        this.getData();
    }
}
</script>