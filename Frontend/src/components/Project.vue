<script setup>
import { ref, onMounted } from 'vue'
import { getMergedReports, getProject } from '../api/api';
import { RouterLink, useRoute  } from 'vue-router';
import Spinner from './Spinner.vue'


const loadingProject = ref(true);
const route = useRoute();
const project = ref(null);


onMounted(async () => {
    project.value = await getProject(route.params.id)
    loadingProject.value = false;
})

const loadingReport = ref(false);
const report = ref(null);
const from = ref(new Date("2024-01-01T02:00:00+02:00"))
const to = ref(new Date("2024-01-14T02:00:00+02:00"))

const loadReport = async () => {
    loadingReport.value = true;
    report.value = await getMergedReports(from, to);
    loadingReport.value = false;
}
</script>
<template>
    <div class="h-full w-full space-y-3 my-6">
        <router-link class="button" :to="{ name: 'Home'}">Home page</router-link>
        <div class="mx-auto h-10 flex flex-col items-center justify-items-center w-full" v-if="loadingProject">
            <Spinner></Spinner>
        </div>
        <template v-else>
            <div class="text-center space-y-3">
                <h1>{{ project.name }}</h1>
                <p>{{ project.description }}</p>
                <button class="w-32 button" @click.prevent="loadReport">Show table</button>
            </div>
            <div class="mx-auto h-10 flex flex-col items-center justify-items-center w-full" v-show="loadingReport">
                <Spinner></Spinner>
            </div>

            <div class="overflow-x-auto shadow-lg mx-auto bg-gray-800 rounded-lg w-10/12 my-3" v-if="report"
                v-show="!loadingReport">
                <table class="w-full px-4">
                    <thead>
                        <tr class="">
                            <th rowspan="2">Date</th>
                            <th colspan="3">Duration</th>
                            <th colspan="1" rowspan="2">Total Chats</th>
                            <th colspan="3">Ratings</th>
                            <th colspan="2">Response time</th>
                            <th rowspan="2">Tags</th>
                        </tr>
                        <tr>
                            <th>Agents Chatting Duration</th>
                            <th>Count</th>
                            <th>Duration</th>

                            <th>Chats</th>
                            <th>Bad</th>
                            <th>Good</th>

                            <th>Count</th>
                            <th>Time</th>
                        </tr>
                    </thead>

                    <tbody class="">
                        <tr v-for="record in report.dates" :key="record.date">
                            <td class="font-semibold">
                                <span class="w-max">{{ record.date }}</span>
                            </td>

                            <td>{{ record['duration-report'].agents_chatting_duration }}</td>
                            <td>{{ record['duration-report'].count }}</td>
                            <td>{{ record['duration-report'].duration }}</td>

                            <td>{{ record['total-chats-report'].total }}</td>

                            <td>{{ record['ratings-report'].chats }}</td>
                            <td>{{ record['ratings-report'].bad }}</td>
                            <td>{{ record['ratings-report'].good }}</td>

                            <td>{{ record['response-time-report'].count }}</td>
                            <td>{{ record['response-time-report'].response_time }}</td>

                            <td>
                                <div class="text-justify grid grid-cols-1 md:grid-cols-2 gap-3">
                                    <div v-for="[key, val] in Object.entries(record['tags-report'])">
                                        {{ key }} : {{ val }}
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr class="font-bold">
                            <td></td>
                            <td colspan="3">Total: {{ report['total-duration-report'] }}</td>
                            <td>Total: {{ report['total-total-chats-report'] }}</td>
                            <td colspan="3">Total: {{ report['total-ratings-report'] }}</td>
                            <td colspan="2">Total: {{ report['total-response-time-report'] }}</td>
                            <td colspan="1">Total: {{ report['total-tags-report'] }}</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </template>
    </div>
</template>