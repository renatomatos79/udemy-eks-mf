<script setup>
import { GoogleMap, AdvancedMarker, Polygon, InfoWindow, Polyline } from 'vue3-google-map';
import { onMounted, ref, computed } from 'vue';
import Header from './Header.vue';
import Filter from './Filter.vue';
import { REPORTED_LOCATIONS, ALL_TYPES } from '@/constants/all-types.const';

const selectedItem = ref('' | null);
const pinOptions = { background: '#FBBC04' }
const bikePinOptions = { background: 'blue' }
const truckPinOptions = { background: 'green' }
const carPinOptions = { background: 'black' }
const reportPinOptions = { background: 'pink' }

const center = ref({ lat: 0, lng: 0 });
const buildingsAreaCoords = ref([]);
const googleMapsApiKey = process.env.VUE_APP_GOOGLE_MAPS_API_KEY;
const settings = ref({
  filter: {
    visible: true
  }
});

const dataSourceBikes = ref([])
const dataSourceTrucks = ref([])
const dataSourceCars = ref([])

const mapsSize = computed(() => settings.value.filter.visible ? 'col-9' : 'col-12');


const dataSourceCarsWithTarget = computed(() => {
  return dataSourceCars.value.filter(f => f.status === 'inactive')
})

const buildingsAreaCoordsOptions = computed(() => {
  return {
    paths: buildingsAreaCoords.value ?? [],
    strokeColor: '#FF0000',
    strokeOpacity: 0.8,
    strokeWeight: 2,
    fillColor: '#FF0000',
    fillOpacity: 0.35,
  }
})

const getSelectedItem = computed(() => {
  if (!selectedItem.value) {
    return null;
  }
  // get the selected item
  const item = ALL_TYPES.find(f => f.itemId === selectedItem.value)

  // if item is a bike
  if (item.itemType === 'bike') {
    return dataSourceBikes.value.find(f => f.itemId === selectedItem.value)
  }

  // if item is a truck
  if (item.itemType === 'truck') {
    return dataSourceTrucks.value.find(f => f.itemId === selectedItem.value)
  }

  // if item is a car
  if (item.itemType === 'car') {
    return dataSourceCars.value.find(f => f.itemId === selectedItem.value)
  }

  return item;
})

onMounted(() => {
  console.log('key: ', googleMapsApiKey);
  const locations = getBuildings().map(b => b.location)
  const calc = calculateCenter(locations);
  center.value = { lat: calc.lat, lng: calc.lng };
  buildingsAreaCoords.value = [...locations, locations[0]];
  buildDataSources();
})

function getTargetPath(selectedCar) {
  const coordinates = [
    { lat: selectedCar.location.lat, lng: selectedCar.location.lng },
    { lat: selectedCar.target.lat, lng: selectedCar.target.lng },
  ]

  const targetPath = {
    path: coordinates,
    geodesic: true,
    strokeColor: 'black',
    strokeOpacity: 1.0,
    strokeWeight: 2,
  }

  return targetPath
}

function getBuildings() {
  return ALL_TYPES.filter(f => f.itemType === 'building')
}

function buildDataSources() {
  selectedItem.value = null;
  dataSourceBikes.value = getBikes()
  dataSourceTrucks.value = getTrucks()
  dataSourceCars.value = getCars()
}

function getBikes() {
  const bikes = ALL_TYPES.filter(f => f.itemType === 'bike')
  const result = []
  bikes.forEach(bike => {
    const latitude = bike.building.latitude;
    const longitude = bike.building.longitude;
    const fakeDistance = bike.status === 'active' ? getRandomBetween(0.0010, 1) : 0;
    const fakeDirection = getRandomDirection(["north", "east", "west"]);
    const newLocation = addDistanceToLocation(latitude, longitude, fakeDistance, fakeDirection);
    const title = `Bike ${bike.itemId} - Unidade: ${bike.building.name} - Status: ${bike.status}`;
    result.push({ ...bike, title, location: newLocation });
  })
  return result;
}

function getTrucks() {
  const trucks = ALL_TYPES.filter(f => f.itemType === 'truck')
  const result = []
  trucks.forEach(truck => {
    const latitude = truck.building.latitude;
    const longitude = truck.building.longitude;
    const fakeDistance = truck.status === 'active' ? getRandomBetween(0.0010, 1) : 0;
    const fakeDirection = getRandomDirection(["north", "east", "west"]);
    const newLocation = addDistanceToLocation(latitude, longitude, fakeDistance, fakeDirection);
    const title = `Truck ${truck.itemId} - Unidade: ${truck.building.name} - Status: ${truck.status}`;
    result.push({ ...truck, title, location: newLocation });
  })
  return result;
}

function getCars() {
  const cars = ALL_TYPES.filter(f => f.itemType === 'car')
  const result = []
  cars.forEach(car => {
    const latitude = car.building.latitude;
    const longitude = car.building.longitude;
    const fakeDistance = car.status === 'active' ? getRandomBetween(0.0010, 1) : 0;
    const fakeDirection = getRandomDirection(["north", "east", "west"]);
    const newLocation = addDistanceToLocation(latitude, longitude, fakeDistance, fakeDirection);
    const newTarget = car.status === 'inactive' ? getRandonReportedLocation() : car.target;
    const details = newTarget.details !== '' ? ` - Chamado: ${newTarget.details}` : '';
    const title = `Car ${car.itemId} - Unidade: ${car.building.name} - Status: ${car.status}` + details;

    if (car.status === 'inactive') {
      console.log('newTarget: ', newTarget)
    }

    result.push({ ...car, title, location: newLocation, target: newTarget });
  })
  return result;
}


function handleFilterClick() {
  settings.value.filter.visible = !settings.value.filter.visible
}

function handleRefreshClick() {
  buildDataSources()
}

function handleIconClick(itemId) {
  selectedItem.value = itemId;
}

function calculateCenter(locations) {
  const total = locations.reduce(
    (acc, loc) => {
      acc.lat += loc.lat;
      acc.lng += loc.lng;
      return acc;
    },
    { lat: 0, lng: 0 }
  );

  const center = {
    lat: total.lat / locations.length,
    lng: total.lng / locations.length,
  };

  return center;
}

function getRandomBetween(min, max) {
  return Math.random() * (max - min) + min;
}

function getRandomDirection(directions = ["north", "south", "east", "west"]) {
  const randomIndex = Math.floor(Math.random() * directions.length);
  return directions[randomIndex];
}

function getRandonReportedLocation() {
  try {
    const randomIndex = Math.floor(Math.random() * REPORTED_LOCATIONS.length);
    return REPORTED_LOCATIONS[randomIndex];
  } catch {
    return REPORTED_LOCATIONS[0];
  }
}

function addDistanceToLocation(lat, lng, distanceKm, direction = 'north') {
  const earthRadiusKm = 6371; // Radius of Earth in kilometers

  // Convert distance to radians (distance in km / radius of Earth)
  const distanceRadians = distanceKm / earthRadiusKm;

  // Calculate new latitude and longitude based on direction
  let newLat = lat;
  let newLng = lng;

  switch (direction.toLowerCase()) {
    case 'north':
      newLat = lat + (distanceRadians * (180 / Math.PI));
      break;
    case 'south':
      newLat = lat - (distanceRadians * (180 / Math.PI));
      break;
    case 'east':
      newLng = lng + (distanceRadians * (180 / Math.PI)) / Math.cos(lat * (Math.PI / 180));
      break;
    case 'west':
      newLng = lng - (distanceRadians * (180 / Math.PI)) / Math.cos(lat * (Math.PI / 180));
      break;
    default:
      throw new Error("Invalid direction: use 'north', 'south', 'east', or 'west'");
  }

  return { lat: newLat, lng: newLng };
}
</script>

<template>
  <div class="dashboard--container">
    <div class="row dashboard--header">
      <div class="col-12">
        <Header @filter-click="handleFilterClick" @refresh-click="handleRefreshClick" />
      </div>
    </div>
    <div class="row g-0">
      <div class="col-3" v-if="settings.filter.visible">
        <Filter @filter-click="handleFilterClick" @icon-click="handleIconClick" />
      </div>
      <div :class="mapsSize">
        <GoogleMap mapId="MapsMonitor" :api-key="googleMapsApiKey" style="width: 100%; height: 800px" :center="center"
          :zoom="15">
          <AdvancedMarker v-for="item in getBuildings()" :key="item.itemId"
            :options="{ position: item.location, title: item.title }" :pin-options="pinOptions" />

          <AdvancedMarker v-for="item in dataSourceBikes" :key="item.itemId"
            :options="{ position: item.location, title: item.title }" :pin-options="bikePinOptions" />

          <AdvancedMarker v-for="item in dataSourceTrucks" :key="item.itemId"
            :options="{ position: item.location, title: item.title }" :pin-options="truckPinOptions" />

          <AdvancedMarker v-for="item in dataSourceCars" :key="item.itemId"
            :options="{ position: item.location, title: item.title }" :pin-options="carPinOptions" />

          <InfoWindow v-if="selectedItem" :key="selectedItem" :options="{ position: getSelectedItem.location }">
            {{ getSelectedItem.title }}
          </InfoWindow>

          <Polygon :options="buildingsAreaCoordsOptions" />

          <template v-for="item in dataSourceCarsWithTarget" :key="item.itemId">
            <Polyline :options="getTargetPath(item)" />
            <AdvancedMarker 
              :options="{ position: {lat: item.target.lat, lng: item.target.lng }, 
              title: item.target.details }" 
              :pin-options="reportPinOptions" />
          </template>
          
        </GoogleMap>
      </div>
    </div>
  </div>
</template>
