<script setup>
import { defineProps } from 'vue';
import { RouterLink } from 'vue-router';

defineProps({
    project: {
        type: Object,
        required: true
    }
})

</script>

<template>
    <div class="relative flex flex-col mt-6 text-gray-700 bg-white shadow-md bg-clip-border rounded-xl w-96">
        <div class="p-6">
            <h5
                class="block mb-2 font-sans text-xl antialiased font-semibold leading-snug tracking-normal text-blue-gray-900">
                {{ project.name }}
            </h5>
            <p class="block font-sans text-base antialiased font-light leading-relaxed text-inherit">
                {{ project.description }}
            </p>
        </div>
        <div class="p-6 pt-0">
            <router-link :to="{ name: 'Project', params: { id: project.id } }" class="button">
                Open
            </router-link>
        </div>
    </div>
</template>