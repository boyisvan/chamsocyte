<script setup>
import { RouterLink, RouterView } from 'vue-router'


import Bacsi from '../components/admin/bacsi.vue';
import Benhnhan from '../components/admin/benhnhan.vue';
import Hoadon from '../components/admin/hoadon.vue';
import Dichvu from '../components/admin/dichvu.vue';
import Thuoc from '../components/admin/thuoc.vue';
import Chuyenkhoa from '../components/admin/chuyenkhoa.vue';

</script>

<template>
    <div class="container">
        <div class="mainApp container">
            <div class="title">
                <h1 class="d-flex justify-content-center">Hệ thống quản lí chăm sóc sức khỏe</h1>
                <h5 class="d-flex justify-content-center">
                    <span id="dynamic-text">~ </span>
                </h5>
            </div>

            <nav class="navbar navbar-expand-sm navbar-dark">
                <ul class="navbar-nav ">
                    <router-link class="btn btn-light btn-outline-danger rl " to="/">Quay lại trang chủ</router-link>
                    <router-link class="btn btn-light btn-outline-primary rl" to="/bacsi">Bác sĩ</router-link>
                    <router-link class="btn btn-light btn-outline-success  rl" to="/chuyenkhoa">Chuyên khoa</router-link>
                    <router-link class="btn btn-light btn-outline-warning rl" to="/benhnhan">Bệnh nhân</router-link>
                    <router-link class="btn btn-light btn-outline-info  rl" to="/thuoc">Thông tin thuốc</router-link>
                    <router-link class="btn btn-light btn-outline-dark  rl" to="/dichvu">Dịch vụ</router-link>
                    <router-link class="btn btn-light btn-outline-primary rl  " to="/hoadon">Hóa đơn</router-link>
                </ul>
            </nav>
            <router-view></router-view>
        </div>
    </div>
</template>


<script>
export default {
    mounted() {
        function animateText() {
            const textElement = document.getElementById("dynamic-text");
            const text = "VueJS + ResFul API    ";
            textElement.innerHTML = '';

            let index = 0;

            function addNextCharacter() {
                if (index < text.length) {
                    textElement.innerHTML += text.charAt(index);
                    index++;
                } else {
                    index = 0;
                    textElement.innerHTML = '';
                }
            }

            setInterval(addNextCharacter, 130); // Thời gian giữa mỗi ký tự (milliseconds)
        }

        animateText();
    },
};
</script>






<style>
@media (max-width:1000px) and (min-width:600px) {
    .navbar-nav {
        display: flex;
        flex-wrap: wrap;
        justify-content: space-around;
        align-items: center;

    }

    .rl {
        width: 40%;
        height: 40px;
        margin: 5px;
    }
}

@media (max-width:600px) and (min-width:300px) {
    .navbar-nav {
        width: 100%;
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
        align-items: center;
        flex-direction: row;

    }

    .rl {
        /* width: 160px; */
        height: 40px;
        margin: 5px;
    }
}

@media (min-width:1000px) and (max-width:1400px) {
    .navbar-nav {
        display: flex;
        flex-wrap: wrap;
        justify-content: space-around;
        align-items: center;
    }

    .rl {
        width: 30%;
        height: 40px;
        margin: 5px;
    }
}

.rl {
    margin-left: 10px;
}

body {
    font-family: Arial, sans-serif;
    background-color: rgb(209, 213, 223);
    margin: 0;
    padding: 0;
    display: flex;
    justify-content: center;
    align-items: center;
    /* height: 100vh; */
    /* background: url('@/assets/photo/ducvan.mp4'); */
}


#dynamic-text {
    width: 250px;
    font-family: system-ui, -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
}

.mainApp {
    background: white;
    border-radius: 10px;
    padding: 20px;
    position: relative;
    max-height: 600px;
    overflow-y: auto;
    box-shadow: 0 0px 100px rgba(23, 238, 4, 0.2);
}

.mainApp h1 {
    color: #333;
    text-align: center;
    font-size: 2rem;
}

.mainApp h5 {
    color: #555;
    text-align: center;
    font-size: 1rem;
}



.mainApp::-webkit-scrollbar {
    width: 12px;
}

.mainApp::-webkit-scrollbar-thumb {
    background: #3498db;
    border-radius: 16px;
}

.mainApp::-webkit-scrollbar-thumb:hover {
    background: #007acc;
}


.mainApp h5 {
    height: 20px;
}
</style>
