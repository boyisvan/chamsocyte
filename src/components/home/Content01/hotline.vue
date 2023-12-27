<template>
    <div class="text-center ">
        <h5>Số điện thoại hỗ trợ </h5>
        <div class="databacsi">
            <table class="table table-bordered table-hover text-center align-items-center  ">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Phòng</th>
                        <th>Số hotline</th>
                        <th>Trạng thái</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="hotline in  hotline " :key="hotline.id"
                        style="font-family: Arial, Helvetica, sans-serif;font-size: 14px;">
                        <td>{{ hotline.id }}</td>
                        <td>{{ hotline.phong }}</td>
                        <td>
                            {{ hotline.sohotline }}
                            <i class="fa-solid fa-copy" @click="copyToClipboard(hotline.sohotline)"
                                style="margin-left: 5px; cursor: pointer; color: rgb(227, 233, 220); background-color: rgb(48, 188, 48); font-size: 11px; padding: 6px; border-radius: 5px;">
                            </i>
                        </td>
                        <td>
                            <p
                                :class="{ 'alert1': true, 'alert-success': hotline.trangthai === 'Hoạt động', 'alert-warning': hotline.trangthai === 'Đang chờ', 'alert-danger ': hotline.trangthai === 'Bảo trì' }">
                                {{ hotline.trangthai }}
                            </p>
                        </td>
                    </tr>
                </tbody>
            </table>

        </div>
    </div>
</template>

<script>
import axios from 'axios';
import Swal from 'sweetalert2';
import "@/assets/styles/content01.css";
export default {
    data() {
        return {
            hotline: [],
            modalTitle: "",
            id: 0,
            phong: "",
            sohotline: "",
            trangthai: "",
        }
    },
    methods: {
        getData() {
            axios.get("https://localhost:7022/api/Hotline").then((response) => {
                this.hotline = response.data;
            });
        },
        copyToClipboard(text) {
            // Tạo một thẻ textarea ẩn để sao chép văn bản vào đó
            const textarea = document.createElement('textarea');
            textarea.value = text;
            document.body.appendChild(textarea);

            // Chọn và sao chép văn bản trong thẻ textarea
            textarea.select();
            document.execCommand('copy');

            // Xóa thẻ textarea sau khi sao chép
            document.body.removeChild(textarea);
            Swal.fire({
                title: "Sao chép thành công số hotline !",
                text: text,
                icon: "success"
            });
        }
    },
    mounted: function () {
        this.getData();
    }
}
</script>