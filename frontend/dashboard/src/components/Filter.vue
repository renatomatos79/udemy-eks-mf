<script setup>
import { ref, computed } from 'vue';
import BuildingIcon from './icons/BuildingIcon.vue';
import CarIcon from './icons/CarIcon.vue';
import TruckIcon from './icons/TruckIcon.vue';
import BikeIcon from './icons/BikeIcon.vue';
import SearchIcon from './icons/SearchIcon.vue';
import FilterIcon from './icons/FilterIcon.vue';
import ArrowLeftIcon from './icons/ArrowLeftIcon.vue';
import Card from './Card.vue';
import { ALL_TYPES } from '@/constants/all-types.const';

const emit = defineEmits(['filter-click', 'icon-click']);

const filter = ref('');
const showBuildings = ref(true);
const showCars = ref(true);
const showBikes = ref(true);
const showTrucks = ref(true);


const filteredTypes = computed(() => {
    let list = filter.value === '' ? ALL_TYPES : ALL_TYPES.filter((item) => {
        return item.itemId.includes(filter.value);
    });

    if (!showBuildings.value) {
        list = list.filter((item) => item.itemType !== 'building');
    }

    if (!showCars.value) {
        list = list.filter((item) => item.itemType !== 'car');
    }

    if (!showBikes.value) {
        list = list.filter((item) => item.itemType !== 'bike');
    }

    if (!showTrucks.value) {
        list = list.filter((item) => item.itemType !== 'truck');
    }

    return list;
});

const handleIconClick = (itemId) => {
    console.log('Icon clicked', itemId);
    emit('icon-click', itemId);
}
</script>

<template>
    <div class="row">
        <div class="row">
            <div class="d-flex d-flex justify-content-between m-1">
                <div class="col-10">
                    <FilterIcon />
                    <span class="H6 col-10 align-middle"> FILTER </span>
                </div>
                <div class="col-2 mx-1 d-flex justify-content-end">
                    <ArrowLeftIcon class="cursor-pointer" :size="32" @click="emit('filter-click')" />
                </div>
            </div>
        </div>
        <div class="row m-2">
            <div class="input-group mt-1 col-12">
                <input type="text" v-model="filter" class="form-control" placeholder="" aria-label="" aria-describedby="button-addon2">
                <button class="btn btn-outline-secondary" type="button" id="button-addon2">
                    <SearchIcon />
                </button>
            </div>
        </div>
        <div class="row m-2">
            <div class="btn-group" role="group" aria-label="Basic checkbox toggle button group">
                <input type="checkbox" class="btn-check" id="btncheck1" autocomplete="off" v-model="showBuildings" :true-value="true" :false-value="false">
                <label class="btn btn-outline-primary" for="btncheck1">
                    <BuildingIcon :color="showBuildings ? 'white' : 'black'" />
                </label>
                <input type="checkbox" class="btn-check" id="btncheck2" autocomplete="off" v-model="showCars" :true-value="true" :false-value="false" >
                <label class="btn btn-outline-primary" for="btncheck2">
                    <CarIcon :color="showCars ? 'white' : 'black'" />
                </label>
                <input type="checkbox" class="btn-check" id="btncheck3" autocomplete="off" v-model="showBikes" :true-value="true" :false-value="false">
                <label class="btn btn-outline-primary" for="btncheck3">
                    <BikeIcon :color="showBikes ? 'white' : 'black'" />
                </label>
                <input type="checkbox" class="btn-check" id="btncheck4" autocomplete="off" v-model="showTrucks" :true-value="true" :false-value="false">
                <label class="btn btn-outline-primary" for="btncheck4">
                    <TruckIcon :color="showTrucks ? 'white' : 'black'" />
                </label>
            </div>
        </div>
        <div class="row" v-for="item in filteredTypes">
            <Card 
                :itemType="item.itemType" 
                :itemId="item.itemId" 
                :status="item.status" 
                :key="item.itemId"
                @click="handleIconClick"
                />
        </div>
    </div>
</template>

<style scoped>
.cursor-pointer {
    cursor: pointer;
}
</style>