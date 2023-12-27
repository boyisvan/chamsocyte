<template>
    <div class="text-center ">
        <h5>Các bác sĩ nổi tiếng </h5>
        <div class="databacsi">
            <table class="table table-bordered table-hover text-center align-items-center  ">
                <thead>
                    <tr>
                        <th>Mã</th>
                        <th>Tên</th>
                        <th>Chuyên khoa</th>
                        <th>Ảnh</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="bacsi in bacsi" :key="bacsi.idBacSi"
                        style="font-family: Arial, Helvetica, sans-serif;font-size: 14px;">
                        <td>{{ bacsi.idBacSi }}</td>
                        <td>{{ bacsi.tenBacSi }}</td>
                        <td>
                            {{ bacsi.chuyenKhoa === '1' ? 'khoa nội' :
                                bacsi.chuyenKhoa === '2' ? 'khoa ngoại' :
                                    bacsi.chuyenKhoa === '3' ? 'khoa tai mũi họng' :
                                        'chuyên ngành'
                            }}
                        </td>
                        <td><img style="max-width: 40px;max-height: 40px;" :src="bacsi.photoFileName"></td>
                    </tr>
                </tbody>
            </table>

        </div>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    data() {
        return {
            bacsi: [],
            modalTitle: "",
            idBacSi: 0,
            tenBacSi: "",
            chuyenKhoa: "",
            photoFileName: "",
        }
    },
    methods: {
        getData() {
            axios.get("https://localhost:7022/api/BacSi").then((response) => {
                this.bacsi = response.data;
            });
        },
    },
    mounted: function () {
        this.getData();
    }
}
</script>