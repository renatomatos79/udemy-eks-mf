export const REPORTED_LOCATIONS = [
  { lat: -22.9056, lng: -43.2094, details: "roubo" },
  { lat: -22.9083, lng: -43.1767, details: "assalto" },
  { lat: -22.9189, lng: -43.2341, details: "violência doméstica" },
  { lat: -22.9321, lng: -43.2202, details: "colisão carro" },
  { lat: -22.9443, lng: -43.2047, details: "tombamento" },
  { lat: -22.9177, lng: -43.1985, details: "atropelamento" },
  { lat: -22.9213, lng: -43.2338, details: "afogamento" },
  { lat: -22.9309, lng: -43.2029, details: "roubo" },
  { lat: -22.9124, lng: -43.2135, details: "assalto" },
  { lat: -22.9265, lng: -43.2273, details: "violência doméstica" },
  { lat: -22.9390, lng: -43.2125, details: "colisão carro" },
  { lat: -22.9087, lng: -43.1928, details: "tombamento" },
  { lat: -22.9196, lng: -43.2267, details: "atropelamento" },
  { lat: -22.9365, lng: -43.2144, details: "afogamento" },
  { lat: -22.9023, lng: -43.2051, details: "roubo" },
  { lat: -22.9146, lng: -43.2019, details: "assalto" },
  { lat: -22.9235, lng: -43.2372, details: "violência doméstica" },
  { lat: -22.9314, lng: -43.2187, details: "colisão carro" },
  { lat: -22.9462, lng: -43.1935, details: "tombamento" },
  { lat: -22.9211, lng: -43.2241, details: "atropelamento" },
  { lat: -22.9102, lng: -43.2073, details: "afogamento" },
  { lat: -22.9059, lng: -43.1834, details: "roubo" },
  { lat: -22.9203, lng: -43.2142, details: "assalto" },
  { lat: -22.9332, lng: -43.2361, details: "violência doméstica" },
  { lat: -22.9483, lng: -43.2117, details: "colisão carro" },
  { lat: -22.9119, lng: -43.2283, details: "tombamento" },
  { lat: -22.9254, lng: -43.2214, details: "atropelamento" },
  { lat: -22.9373, lng: -43.2039, details: "afogamento" },
  { lat: -22.9037, lng: -43.1975, details: "roubo" },
  { lat: -22.9128, lng: -43.2158, details: "assalto" },
  { lat: -22.9285, lng: -43.2234, details: "violência doméstica" },
  { lat: -22.9401, lng: -43.2006, details: "colisão carro" },
  { lat: -22.9167, lng: -43.2105, details: "tombamento" },
  { lat: -22.9279, lng: -43.1942, details: "atropelamento" },
  { lat: -22.9456, lng: -43.2211, details: "afogamento" },
  { lat: -22.9181, lng: -43.1879, details: "roubo" },
  { lat: -22.9223, lng: -43.2312, details: "assalto" },
  { lat: -22.9356, lng: -43.2081, details: "violência doméstica" },
  { lat: -22.9492, lng: -43.1934, details: "colisão carro" },
  { lat: -22.9084, lng: -43.2235, details: "tombamento" },
  { lat: -22.9311, lng: -43.2189, details: "atropelamento" },
  { lat: -22.9463, lng: -43.2067, details: "afogamento" },
  { lat: -22.9155, lng: -43.2201, details: "roubo" },
  { lat: -22.9284, lng: -43.1996, details: "assalto" },
  { lat: -22.9405, lng: -43.2143, details: "violência doméstica" },
  { lat: -22.9471, lng: -43.2259, details: "colisão carro" },
  { lat: -22.9219, lng: -43.2028, details: "tombamento" },
  { lat: -22.9382, lng: -43.2184, details: "atropelamento" },
  { lat: -22.9094, lng: -43.2275, details: "afogamento" }
];

const POLICE_STATIONS = [
    { name: "Delegacia  Apoio ao Turismo (DEAT)", latitude: -22.9637, longitude: -43.2075 },
    { name: "12ª Delegacia de Polícia - Copacabana", latitude: -22.9664, longitude: -43.1875 },
    { name: "15ª Delegacia de Polícia - Gávea", latitude: -22.9825, longitude: -43.2228 },
    { name: "19ª Delegacia de Polícia - Tijuca", latitude: -22.9269, longitude: -43.2317 },
    { name: "Delegacia de Polícia Civil - Botafogo", latitude: -22.9475, longitude: -43.1861 },
  ];

export const DEFAULT_BUILDING_COLOR = 'orange';  
export const DEFAULT_CAR_COLOR = 'black';  
export const DEFAULT_BIKE_COLOR = 'blue';  
export const DEFAULT_TRUCK_COLOR = 'green';  

export const ALL_TYPES = [
    { itemType: 'building', itemId: 'DEAT', status: 'active', title: POLICE_STATIONS[0].name, location: { lat: POLICE_STATIONS[0].latitude, lng: POLICE_STATIONS[0].longitude } },
    { itemType: 'building', itemId: '12º Copacabana', status: 'active', title: POLICE_STATIONS[1].name, location: { lat: POLICE_STATIONS[1].latitude, lng: POLICE_STATIONS[1].longitude } },
    { itemType: 'building', itemId: '15º Gávea', status: 'active', title: POLICE_STATIONS[2].name, location: { lat: POLICE_STATIONS[2].latitude, lng: POLICE_STATIONS[2].longitude } },
    { itemType: 'building', itemId: '19º Tijuca', status: 'active', title: POLICE_STATIONS[3].name, location: { lat: POLICE_STATIONS[3].latitude, lng: POLICE_STATIONS[3].longitude } },
    { itemType: 'building', itemId: 'Del. Botafogo', status: 'active', title: POLICE_STATIONS[4].name, location: { lat: POLICE_STATIONS[4].latitude, lng: POLICE_STATIONS[4].longitude } },
    
    { itemType: 'car', itemId: '90-NL-67', status: 'active', km: 200000, building: POLICE_STATIONS[1], target: { lat: 0, lng: 0, details: '' } },
    { itemType: 'car', itemId: '90-NL-68', status: 'active', km: 200000, building: POLICE_STATIONS[1], target: { lat: 0, lng: 0, details: '' } },
    { itemType: 'car', itemId: '90-NL-69', status: 'inactive', km: 200000, building: POLICE_STATIONS[1], target: { lat: 0, lng: 0, details: '' } },
    { itemType: 'car', itemId: '90-NL-70', status: 'broken', km: 200000, building: POLICE_STATIONS[1], target: { lat: 0, lng: 0, details: '' } },

    { itemType: 'bike', itemId: '12-16-68', status: 'active', km: 200000, building: POLICE_STATIONS[0], target: { lat: 0, lng: 0, details: '' } },
    { itemType: 'bike', itemId: '12-16-69', status: 'active', km: 200000, building: POLICE_STATIONS[0], target: { lat: 0, lng: 0, details: '' } },
    { itemType: 'bike', itemId: '12-16-70', status: 'active', km: 200000, building: POLICE_STATIONS[0], target: { lat: 0, lng: 0, details: '' } },
    { itemType: 'bike', itemId: '12-16-71', status: 'inactive', km: 200000, building: POLICE_STATIONS[0], target: { lat: 0, lng: 0, details: '' } },
    { itemType: 'bike', itemId: '12-16-72', status: 'broken', km: 200000, building: POLICE_STATIONS[0], target: { lat: 0, lng: 0, details: '' } },

    { itemType: 'truck', itemId: '90-NL-71', status: 'active', km: 200000, building: POLICE_STATIONS[4], target: { lat: 0, lng: 0, details: '' } },
    { itemType: 'truck', itemId: '90-NL-72', status: 'active', km: 200000, building: POLICE_STATIONS[4], target: { lat: 0, lng: 0, details: '' } },
    { itemType: 'truck', itemId: '90-NL-73', status: 'active', km: 200000, building: POLICE_STATIONS[4], target: { lat: 0, lng: 0, details: '' } },
    { itemType: 'truck', itemId: '90-NL-74', status: 'inactive', km: 200000, building: POLICE_STATIONS[4], target: { lat: 0, lng: 0, details: '' } },
    { itemType: 'truck', itemId: '90-NL-75', status: 'inactive', km: 200000, building: POLICE_STATIONS[3], target: { lat: 0, lng: 0, details: '' } },
    { itemType: 'truck', itemId: '90-NL-76', status: 'broken', km: 200000, building: POLICE_STATIONS[3], target: { lat: 0, lng: 0, details: '' } }
]