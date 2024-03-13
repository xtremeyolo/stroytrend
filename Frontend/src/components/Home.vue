<script setup>
import { ref, onMounted } from 'vue'
import { getProjects } from '../api/api'
import ProjectCard from './ProjectCard.vue'
import Spinner from './Spinner.vue';
const projects = ref([])
const loading = ref(true);

onMounted( async () => {
    projects.value = await getProjects();
    loading.value = false;
})

</script>
<template>
    <div class="w-full h-full place-content-center flex" v-if="loading">
        <Spinner class="self-center"></Spinner>
    </div>
    <div v-else
        class="h-full w-full grid grid-cols-1 md:grid-cols-2 xl:grid-cols-3 gap-3 container justify-items-center mx-auto">
        <ProjectCard v-for="project of projects" :key="project.id" :project="project"></ProjectCard>
    </div>
</template>