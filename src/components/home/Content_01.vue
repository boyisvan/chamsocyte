<script setup>
import Bacsi from "./Content01/bacsi.vue";
</script>

<template>
    <div class="container_content01">
        <div class="hotline">
            <hotlineVue></hotlineVue>
        </div>
        <div class="bacsi">
            <Bacsi></Bacsi>
        </div>
    </div>
</template>


<script>
import "@/assets/styles/content01.css";
import hotlineVue from './Content01/hotline.vue';

export default {

}
</script>
