let enterpriseZones = JSON.parse(localStorage.getItem('enterprise_zones')) || [
  {
    id: 101,
    zoneName: 'Mangalore',
    admin: 'abc',
    totalMeters: 12,
    status: 'Active',
  },
  {
    id: 102,
    zoneName: 'Bangalore',
    admin: 'xyz',
    totalMeters: 40,
    status: 'De-Activated',
  },
  {
    id: 103,
    zoneName: 'Delhi',
    admin: 'pqr',
    totalMeters: 55,
    status: 'Active',
  },
  {
    id: 104,
    zoneName: 'Mumbai',
    admin: 'abc',
    totalMeters: 60,
    status: 'De-Activated',
  },
  {
    id: 105,
    zoneName: 'Chennai',
    admin: 'xyz',
    totalMeters: 38,
    status: 'Active',
  },
  {
    id: 106,
    zoneName: 'Kolkata',
    admin: 'pqr',
    totalMeters: 42,
    status: 'De-Activated',
  },
];

const ENTERPRISE_METERS_KEY = 'enterpriseMeters';

const defaultMeters = [
  {
    id: 101,
    zone: 'Mangalore',
    owner: 'abc',
    status: 'Active',
    lastReading: '2025-10-07T07:15:13Z',
  },
  {
    id: 102,
    zone: 'Bangalore',
    owner: 'xyz',
    status: 'De-Activated',
    lastReading: '2025-10-07T07:15:13Z',
  },
  {
    id: 103,
    zone: 'Delhi',
    owner: 'pqr',
    status: 'Active',
    lastReading: '2025-10-07T07:15:13Z',
  },
  {
    id: 104,
    zone: 'Mumbai',
    owner: 'abc',
    status: 'De-Activated',
    lastReading: '2025-10-07T07:15:13Z',
  },
  {
    id: 105,
    zone: 'Chennai',
    owner: 'xyz',
    status: 'Active',
    lastReading: '2025-11-09T08:15:14Z',
  },
  {
    id: 106,
    zone: 'Kolkata',
    owner: 'pqr',
    status: 'De-Activated',
    lastReading: '2025-11-15T07:18:13Z',
  },
];

const ENTERPRISE_CHART_KEY = 'enterpriseUsageChart';

const defaultChartData = [
  { name: 'Mangalore', usage: 55 },
  { name: 'Bangalore', usage: 70 },
  { name: 'Delhi', usage: 50 },
  { name: 'Mumbai', usage: 85 },
  { name: 'Chennai', usage: 69 },
  { name: 'Kolkata', usage: 90 },
];

export const enterpriseDataService = {
  getDashboardData() {
    return {
      totalZones: enterpriseZones.length,
      totalMeters: enterpriseZones.reduce((sum, z) => sum + z.totalMeters, 0),
      criticalAlerts: 26,
      avgConsumption: 26,
    };
  },

  getZones() {
    return [
      {
        id: 1,
        name: 'Mangalore',
        lat: 12.9141,
        lng: 74.856,
        meters: 12,
        alerts: 6,
      },
      {
        id: 2,
        name: 'Bangalore',
        lat: 12.9716,
        lng: 77.5946,
        meters: 40,
        alerts: 10,
      },
      {
        id: 3,
        name: 'Delhi',
        lat: 28.6139,
        lng: 77.209,
        meters: 55,
        alerts: 8,
      },
      {
        id: 4,
        name: 'Mumbai',
        lat: 19.076,
        lng: 72.8777,
        meters: 60,
        alerts: 11,
      },
      {
        id: 5,
        name: 'Chennai',
        lat: 13.0827,
        lng: 80.2707,
        meters: 38,
        alerts: 7,
      },
      {
        id: 6,
        name: 'Kolkata',
        lat: 22.5726,
        lng: 88.3639,
        meters: 42,
        alerts: 5,
      },
    ];
  },

  getAlerts() {
    return [
      {
        id: 1,
        title: 'Alert 1',
        description:
          'High consumption detected in Padil zone. Please review meter readings.',
        zone: 'Padil zone',
      },
      {
        id: 2,
        title: 'Alert 2',
        description:
          'Meter offline in Mangalore zone. Check connectivity status.',
        zone: 'Mangalore zone',
      },
      {
        id: 3,
        title: 'Alert 3',
        description: 'Unusual voltage variation in Bajpe zone detected.',
        zone: 'Bajpe zone',
      },
      {
        id: 4,
        title: 'Alert 4',
        description:
          'Data lag in Pumpwell zone, please investigate immediately.',
        zone: 'Pumpwell zone',
      },
    ];
  },

  getEnterpriseZones() {
    return enterpriseZones;
  },

  addZone(newZone) {
    const id = enterpriseZones.length
      ? Math.max(...enterpriseZones.map((z) => z.id)) + 1
      : 1;
    const zone = { id, ...newZone };
    enterpriseZones.push(zone);
    localStorage.setItem('enterprise_zones', JSON.stringify(enterpriseZones));
  },

  updateZone(id, updated) {
    enterpriseZones = enterpriseZones.map((z) =>
      z.id === id ? { ...z, ...updated } : z
    );
    localStorage.setItem('enterprise_zones', JSON.stringify(enterpriseZones));
  },

  deleteZone(id) {
    enterpriseZones = enterpriseZones.filter((z) => z.id !== id);
    localStorage.setItem('enterprise_zones', JSON.stringify(enterpriseZones));
  },

  getEnterpriseMeters() {
    const stored = JSON.parse(localStorage.getItem('enterpriseMeters'));
    if (stored && stored.length > 0) return stored;
    localStorage.setItem('enterpriseMeters', JSON.stringify(defaultMeters));
    return defaultMeters;
  },

  updateMeter(id, updatedMeter) {
    const meters = this.getEnterpriseMeters().map((m) =>
      m.id === id ? { ...m, ...updatedMeter } : m
    );
    localStorage.setItem('enterpriseMeters', JSON.stringify(meters));
  },

  deleteMeter(id) {
    const meters = this.getEnterpriseMeters().filter((m) => m.id !== id);
    localStorage.setItem('enterpriseMeters', JSON.stringify(meters));
  },

  getChartData() {
    const stored = JSON.parse(localStorage.getItem(ENTERPRISE_CHART_KEY));
    if (stored && stored.length > 0) return stored;
    localStorage.setItem(
      ENTERPRISE_CHART_KEY,
      JSON.stringify(defaultChartData)
    );
    return defaultChartData;
  },

  updateChartData(newData) {
    localStorage.setItem(ENTERPRISE_CHART_KEY, JSON.stringify(newData));
  },
};
