<script setup>
import { computed } from 'vue';

import PhoneIcon from './icons/PhoneIcon.vue';
import MapIcon from './icons/MapIcon.vue';
import BuildingIcon from './icons/BuildingIcon.vue';
import TruckIcon from './icons/TruckIcon.vue';
import BikeIcon from './icons/BikeIcon.vue';
import CarIcon from './icons/CarIcon.vue';
import CheckIcon from './icons/CheckIcon.vue';
import FuelIcon from './icons/FuelIcon.vue';
import ToolsIcon from './icons/ToolsIcon.vue';
import AlarmIcon from './icons/AlarmIcon.vue';
import DriverIcon from './icons/DriverIcon.vue';
import KmIcon from './icons/KmIcon.vue';
import NotesIcon from './icons/NotesIcon.vue';

const props = defineProps({
    iconSize: {
        type: Number,
        default: 32
    },
    itemType: {
        type: String,
        default: 'car',
        validator: (prop) => ['building', 'car', 'truck', 'bike'].includes(prop)
    },
    itemId: {
        type: String,
        default: '90 NL 67'
    },
    status: {
        type: String,
        default: 'active',
        validator: (prop) => ['active' | 'inactive' | 'broken'].includes(prop)
    },
    km: {
        type: Number,
        default: 0
    },

})

const emit = defineEmits(['click']);

const isBuilding = computed(() => props.itemType === 'building');
const isCar = computed(() => props.itemType === 'car');
const isTruck = computed(() => props.itemType === 'truck');
const isBike = computed(() => props.itemType === 'bike');
const isBroken = computed(() => props.status === 'broken');
const checkColor = computed(() => {
    switch (props.status) {
        case 'active': return 'green';
        case 'inactive': return 'orange';
        default: return 'red';
    }
});

const handleIconClick = () => {
    emit('click', props.itemId);
}
</script>

<template>
    <div class="card">
        <div class="card-img-top">
            <div class="row">
                <div class="d-flex justify-content-between m-1">
                    <div class="col-5 ms-3">
                        <BuildingIcon v-if="isBuilding" :size="iconSize"  />
                        <CarIcon v-if="isCar" :size="iconSize"  />
                        <TruckIcon v-if="isTruck" :size="iconSize"  />
                        <BikeIcon v-if="isBike" :size="iconSize"  />

                        <span class="H6 mx-2"> {{ itemId }} </span>
                    </div>

                    <div class="col-7 mt-2 px-3 d-flex justify-content-end">
                        <CheckIcon :color="checkColor" class="me-1" />
                        <DriverIcon v-if="!isBuilding" class="me-1" />
                        <ToolsIcon v-if="isBroken" class="me-1" />
                        <NotesIcon class="me-1" />
                        <FuelIcon v-if="!isBike && !isBuilding" class="me-1"/>
                        <KmIcon v-if="!isBike && !isBuilding" class="me-1"/>
                        <PhoneIcon v-if="isBuilding" class="me-1"/>
                        <MapIcon @click="handleIconClick" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>