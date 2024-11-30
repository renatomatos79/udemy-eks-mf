<script setup>
import FilterIcon from './icons/FilterIcon.vue';
import RefreshIcon from './icons/RefreshIcon.vue';
const emit = defineEmits(['filter-click']);
</script>

<template>
    <nav class="navbar navbar-expand-lg bg-body-tertiary">
        <div class="container-fluid">
            <a class="navbar-brand" href="#">Dashboard</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown"
                aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <ul class="navbar-nav d-flex justify-content-end">
                <li class="me-4">
                    <a class="dropdown-item" href="#" @click="emit('refresh-click')">
                        <RefreshIcon size="12" />
                        Refresh
                    </a>
                </li>
                <li>
                    <a class="dropdown-item" href="#" @click="emit('filter-click')">
                        <FilterIcon size="12" />
                        Filter
                    </a>
                </li>
            </ul>
        </div>
    </nav>
</template>