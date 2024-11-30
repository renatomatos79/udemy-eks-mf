<script setup>
const props = defineProps({
    title: {
        type: String,
        default: 'Detalhes do atendimento'
    },
    content: {
        type: String,
        default: ''
    },
})
</script>

<template>
    <div class="accordion" id="accordionPanelsStayOpenExample">
        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button" type="button" data-bs-toggle="collapse"
                    data-bs-target="#panelsStayOpen-collapseOne" aria-expanded="true"
                    aria-controls="panelsStayOpen-collapseOne">
                    {{ title }}
                </button>
            </h2>
            <div id="panelsStayOpen-collapseOne" class="accordion-collapse collapse show">
                <div class="accordion-body">
                    {{ content }}
                </div>
            </div>
        </div>
    </div>
</template>