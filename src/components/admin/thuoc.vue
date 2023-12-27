<template>
    <div>
        <h4>Trang Quản Lí Thuốc</h4>
        <div class="databacsi">

            <button class="btn btn-primary m-2 fload-end" data-bs-toggle="modal" data-bs-target="#themthuoc"
                @click="addClick()">Thêm thuốc</button>

            <table class="table table-bordered table-hover text-center align-items-center  ">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Tên</th>
                        <th>Số lượng</th>
                        <th>Giá bán</th>
                        <th>Nhà Phân phôi</th>
                        <th>Thao tác</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="thuoc in thuoc" :key="thuoc.idThuoc">
                        <td>{{ thuoc.idThuoc }}</td>
                        <td>{{ thuoc.tenThuoc }}</td>
                        <td>{{ thuoc.giaBan }}</td>
                        <td>{{ thuoc.soLuong }}</td>
                        <td>{{ thuoc.nhaPhanPhoi }}</td>
                        <td>
                            <button class="btn btn-outline-warning  btn-sm " data-bs-toggle="modal"
                                data-bs-target="#themthuoc" @click="editClick(thuoc)">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                                    class="bi bi-pencil-square" viewBox="0 0 16 16">
                                    <path
                                        d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                    <path fill-rule="evenodd"
                                        d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
                                </svg>
                            </button> |
                            <button class="btn btn-outline-danger btn-sm " @click="deleteClick(thuoc.idThuoc)">
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

            <div class="modal fade" id="themthuoc" tabindex="-1" aria-labelledby="themthuoclabel" aria-hidden="true">
                <div class="modal-dialog modal-lg modal-dialog-centered ">
                    <div class="modal-content ">
                        <div class="modal-header ">
                            <h5 class="modal-title " id="themthuoclabel">{{ modalTitle }}</h5>
                            <button class="btn-close " data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <div class="input-group mb-3">
                                <span class="input-group-text ">Tên Thuốc</span>
                                <input type="text" class="form-control " v-model="tenThuoc">
                            </div>
                            <div class="input-group mb-3">
                                <span class="input-group-text ">Số lượng</span>
                                <input type="text" class="form-control " v-model="soLuong">
                            </div>
                            <div class="input-group mb-3">
                                <span class="input-group-text ">Giá bán</span>
                                <input type="text" class="form-control " v-model="giaBan">
                            </div>
                            <div class="input-group mb-3">
                                <span class="input-group-text ">Nhà phân phối</span>
                                <input type="text" class="form-control " v-model="nhaPhanPhoi">
                            </div>
                            <button v-if="idThuoc == 0" class="btn btn-primary" @click="createClick()"
                                data-bs-dismiss="modal">Thêm
                                mới</button>
                            <button v-if="idThuoc != 0" class="btn btn-primary " @click="updateClick()"
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
    props: {
    },
    data() {
        return {
            thuoc: [],
            modalTitle: "",
            idThuoc: 0,
            tenThuoc: "",
            soLuong: "",
            giaBan: "",
            nhaPhanPhoi: "",
        }
    },
    methods: {
        getData() {
            axios.get(configURL.thuocURL).then((response) => {
                this.thuoc = response.data;
            });
        },
        addClick() {
            this.modalTitle = "Thêm thông tin thuốc";
            this.idThuoc = 0;
            this.tenThuoc = "";
            this.soLuong = "";
            this.giaBan = "";
            this.nhaPhanPhoi = "";
        },
        editClick(thuoc) {
            this.modalTitle = "Sửa thông tin thuốc";
            this.idThuoc = thuoc.idThuoc;
            this.tenThuoc = thuoc.tenThuoc;
            this.soLuong = thuoc.soLuong;
            this.giaBan = thuoc.giaBan;
            this.nhaPhanPhoi = thuoc.nhaPhanPhoi;
        },
        createClick() {
            axios.post(configURL.thuocURL, {
                tenThuoc: this.tenThuoc,
                soLuong: this.soLuong,
                giaBan: this.giaBan,
                nhaPhanPhoi: this.nhaPhanPhoi,
            }).then((response) => {
                this.getData();
                Swal.fire({
                    title: 'Thêm mới thành công !',
                    icon: 'success',
                    text: response.data,
                })
            });
        },
        updateClick() {
            axios.put(configURL.thuocURL, {
                idThuoc: this.idThuoc,
                tenThuoc: this.tenThuoc,
                soLuong: this.soLuong,
                giaBan: this.giaBan,
                nhaPhanPhoi: this.nhaPhanPhoi
            }).then((response) => {
                this.getData();
                Swal.fire({
                    title: 'Cập nhập thành công !',
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
                    axios.delete(configURL.thuocURL + "/" + id).then((response) => {
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