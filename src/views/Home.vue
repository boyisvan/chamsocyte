<script setup>

import Content_01 from "../components/home/Content_01.vue";
import footerVue from '../components/home/footer.vue';
import bannerVue from '../components/home/banner.vue';
import datlichVue from '../components/home/datlich.vue';
import { RouterLink, RouterView } from 'vue-router';
import loginVue from './login.vue';
</script>

<template>
    <div class="container1">
        <div class="box-top">
            <p class="p-banner">
                <img src="/src/assets/photo/logoweb.png" alt="">
            </p>
        </div>
        <div class="box-bot">
            <!-- ----------------phần nội dung -->
            <bannerVue></bannerVue>
            <br>
            <!----------- đặt lịch thăm khám -->
            <datlichVue></datlichVue>
            <!--------------Content_01 : số hotline và thông tin bác sĩ -->
            <Content_01></Content_01>
            <br>
            <!-- ---------------phần footer -->
            <footerVue></footerVue>
        </div>
        <br>
        <div class="div">
            <loginVue></loginVue>
        </div>
    </div>
</template>


<script>
import "@/assets/styles/home.css";



export default {
}
</script>

<style>
span {
    padding: 5px;
    border-radius: 10px;
    margin-left: 10px;
    border: none;
    width: 150px;
}
</style>