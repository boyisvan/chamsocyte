<template>
    <div id="carouselExampleControlsNoTouching" class="carousel slide" data-bs-touch="false" data-bs-interval="false"
        style="padding: 0 5%;">
        <div class="carousel-inner ass">
            <div class="carousel-item active">
                <div class="welcome">
                    <div class="h">
                        <video muted autoplay loop src="@/assets/photo/duvan.mp4"></video>
                    </div>
                </div>
            </div>
            <div class="col-md-5  carousel-item" v-for="dichvu in dichvu" :key="dichvu.idDichVu">
                <div class="card p-3 mb-2">
                    <div class="d-flex justify-content-between">
                        <div class="d-flex flex-row align-items-center">
                            <div class="icon"
                                style="width: 40px;height: 40px;;overflow: hidden;border-radius: 50%;border :0.5px solid rgb(130, 244, 130)">
                                <!-- <i class="bx bxl-mailchimp"></i> -->
                                <img style="width:100%" src="@/assets/photo/anhcontent1.jpg" alt="">
                            </div>
                            <div class="ms-2 c-details">
                                <p class="mb-0">{{ dichvu.tenDichVu }}</p> <span style="color: rgb(219, 214, 214);">1 days
                                    ago</span>
                            </div>
                        </div>
                        <div class="badge"> <span>Id : {{ dichvu.idDichVu }}</span> </div>
                    </div>
                    <div class="mt-5">
                        <p class="heading1">{{ dichvu.mota }}</p>
                        <div class="mt-5">
                            <div class="progress">
                                <div class="progress-bar" role="progressbar"
                                    :style="{ width: `${(parseInt(dichvu.gia) / 1000000) * 100}%` }"
                                    :aria-valuenow="dichvu.gia" aria-valuemin="0" aria-valuemax="2000000"></div>
                            </div>
                            <div class="mt-3"> <span class="text1">$ {{ dichvu.gia }} <span class="text2"> / 2.000.000 Vnd
                                    </span></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <button style="background-color: rgb(81, 106, 85);width: 25px;" class="carousel-control-prev" type="button"
            data-bs-target="#carouselExampleControlsNoTouching" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button style="background-color: rgb(81, 106, 85);width: 25px;" class="carousel-control-next" type="button"
            data-bs-target="#carouselExampleControlsNoTouching" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class=" visually-hidden">Next</span>
        </button>
    </div>
</template>

<script>
import axios from 'axios';
import "@/assets/styles/banner.css";
export default {
    data() {
        return {
            dichvu: [],
            idDichVu: 0,
            tenDichVu: "",
            gia: "",
            mota: "",

        };
    },
    methods: {
        getData() {
            axios.get("https://localhost:7022/api/DichVu").then((response) => {
                this.dichvu = response.data;
            });
        },
    },
    mounted: function () {
        this.getData();
    }
};
</script>

<style>
.dataDichvu {
    font-family: sans-serif;
}

body {
    background-color: #eee
}

.heading1 {
    font-family: sans-serif;
    font-weight: 100;
}

.card {
    border: none;
    border-radius: 10px
}

.c-details span {
    font-weight: 300;
    font-size: 13px
}

.icon {
    width: 50px;
    height: 50px;
    background-color: #eee;
    border-radius: 15px;
    display: flex;
    align-items: center;
    justify-content: center;
    font-size: 39px
}

.badge span {
    background-color: #fffbec;
    width: 60px;
    height: 25px;
    padding-bottom: 3px;
    border-radius: 5px;
    display: flex;
    color: #fed85d;
    justify-content: center;
    align-items: center
}

.progress {
    height: 10px;
    border-radius: 10px
}

.progress div {
    background-color: red
}

.text1 {
    font-size: 14px;
    font-weight: 600
}

.text2 {
    color: #a5aec0
}
</style>