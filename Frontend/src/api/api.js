export const getProjects = async () => {
    const response = await fetch('/api/projects');
    return await response.json()
}

export const getProject = async (projectId) => {
    const response = await fetch(`/api/projects/${projectId}`);
    return await response.json()
}

const getDurationReport = async function() {
    const response = await fetch('/api/reports/duration');
    return await response.json()
}

const getRatingsReport = async function() {
    const response = await fetch('/api/reports/ratings');
    return await response.json()
}

const getResponseTimeReport = async function() {
    const response = await fetch('/api/reports/response-time');
    return await response.json()
}

const getTagsReport = async function() {
    const response = await fetch('/api/reports/tags');
    return await response.json()
}

const getTotalChatsReport = async function() {
    const response = await fetch('/api/reports/total-chats');
    return await response.json()
}

export const getReports = async function(from, to) {
    // imitate delay
    const [durationReport, ratings, responseTime, tags, totalChats] = await Promise.allSettled(
        [getDurationReport(), getRatingsReport(), getResponseTimeReport(), getTagsReport(), getTotalChatsReport()]
    )

    return [durationReport, ratings, responseTime, tags, totalChats].map(x => x.value)
}

const merge = function (reports) {
    const dates = Object.keys(reports[0].records)
    const merged = {
        dates: []
    }

    for (const [_, value] of dates.entries()) {
        const date = {
            date: value
        }

        for (const report of reports) {
            date[report.name] = report.records[value]
            merged['total-' + report.name] = report.total
        }

        merged.dates.push(date)
    }

    return merged
}

export const getMergedReports = async function(from, to) {
    const reports = await getReports(from, to);
    return merge(reports);
}

