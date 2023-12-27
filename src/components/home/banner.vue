<script setup>
import dicvuVue from './dicvu.vue';
</script>
<template>
    <div>
        <div class="title text-center ">
            <h6 class="d-flex justify-content-center">
                <span id="dynamic-text"> </span>
                <br>
            </h6>
            <btn class="custom-button1 d-flex justify-content-center"
                style="font-family: 'Courier New', Courier, monospace;">
                Thời gian hiện tại : {{ time }}
            </btn>
        </div>
    </div>
    <br>
    <div class="content_main">
        <div style="width: 60%;">
            <dicvuVue></dicvuVue>
        </div>
        <div class="photocontent">
            <img src="@/assets/photo/anhcontent1.jpg" alt="">
        </div>

    </div>
    <br>
</template>

<script>
import "@/assets/styles/banner.css";
import dicvuVue from './dicvu.vue';

export default {
    data() {
        return {
            time: null,
            miliSeconds: null,
        };
    },
    mounted() {
        function animateText() {
            const textElement = document.getElementById("dynamic-text");
            const text = "                                    ";
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

            setInterval(addNextCharacter, 40); // Thời gian giữa mỗi ký tự (milliseconds)
        }

        animateText();

        this.getCurrentTime(); // Gọi getCurrentTime ban đầu
        setInterval(this.getCurrentTime, 1); // Cập nhật mỗi mili giây
    },
    methods: {
        getCurrentTime() {
            const currentTime = new Date();
            const miliSeconds = currentTime.getMilliseconds();
            this.miliSeconds = miliSeconds;
            const options = { hour12: false, timeZone: 'Asia/Ho_Chi_Minh' };
            // this.time = currentTime.toLocaleString('en-US', options) + `.${miliSeconds}`;
            this.time = currentTime.toLocaleString('en-US', options);
        },
    },

};
</script>


<style>
.custom-button1 {
    font-size: 13px;
}
</style>