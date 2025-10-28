import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from 'react-router-dom';
import { useState, useEffect } from 'react';

import NotFound from './pages/Utility/NotFound';
import InternalServerError from './pages/Utility/InternalServerError';
import Maintenance from './pages/Utility/Maintenance';
import AccessDenied from './pages/Utility/AccessDenied';
import Loading from './pages/Utility/Loading';

import Login from './pages/Auth/Login';
import ForgotPassword from './pages/Auth/ForgotPassword';
import ResetPassword from './pages/Auth/ResetPassword';

import Dashboard from './pages/EndUser/Dashboard';
import BillsPayments from './pages/EndUser/BillsPayments';
import MeterData from './pages/EndUser/MeterData';
import AlertsNotifications from './pages/EndUser/AlertsNotifications';
import ProfileSettings from './pages/EndUser/ProfileSettings';
import Logs from './pages/EndUser/Logs';

import ZoneDashboard from './pages/Zone/Dashboard';
import MeterManagement from './pages/Zone/MeterManagement';
import UserManagement from './pages/Zone/UserManagement';
import ReportsAnalytics from './pages/Zone/ReportsAnalytics';
import ZoneSettings from './pages/Zone/SettingsNotifications';

import ProtectedRoute from './components/layout/ProtectedRoute';
import { authService } from './services/authService';
import BillDetails from './pages/EndUser/BillDetails';

function App() {
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    setTimeout(() => {
      setLoading(false);
    }, 400);
  }, []);

  if (loading) {
    return <Loading />;
  }

  if (error === '500') return <InternalServerError />;
  if (error === 'maintenance') return <Maintenance />;
  if (error === 'access-denied') return <AccessDenied />;

  return (
    <Router>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/forgot-password" element={<ForgotPassword />} />
        <Route path="/reset-password" element={<ResetPassword />} />

        <Route
          path="/enduser/dashboard"
          element={
            <ProtectedRoute>
              <Dashboard />
            </ProtectedRoute>
          }
        />
        <Route
          path="/enduser/bills-payments"
          element={
            <ProtectedRoute>
              <BillsPayments />
            </ProtectedRoute>
          }
        />
        <Route
          path="/enduser/meter-data"
          element={
            <ProtectedRoute>
              <MeterData />
            </ProtectedRoute>
          }
        />
        <Route
          path="/enduser/alerts"
          element={
            <ProtectedRoute>
              <AlertsNotifications />
            </ProtectedRoute>
          }
        />
        <Route
          path="/enduser/profile"
          element={
            <ProtectedRoute>
              <ProfileSettings />
            </ProtectedRoute>
          }
        />
        <Route
          path="/enduser/logs"
          element={
            <ProtectedRoute>
              <Logs />
            </ProtectedRoute>
          }
        />
        <Route
          path="/enduser/bill/:receiptId"
          element={
            <ProtectedRoute>
              <BillDetails />
            </ProtectedRoute>
          }
        />
        <Route
          path="/zone/dashboard"
          element={
            <ProtectedRoute>
              <ZoneDashboard />
            </ProtectedRoute>
          }
        />
        <Route
          path="/zone/meter-management"
          element={
            <ProtectedRoute>
              <MeterManagement />
            </ProtectedRoute>
          }
        />
        <Route
          path="/zone/user-management"
          element={
            <ProtectedRoute>
              <UserManagement />
            </ProtectedRoute>
          }
        />
        <Route
          path="/zone/reports"
          element={
            <ProtectedRoute>
              <ReportsAnalytics />
            </ProtectedRoute>
          }
        />
        <Route
  path="/zone/settings"
  element={
    <ProtectedRoute>
      <ZoneSettings />
    </ProtectedRoute>
  }
/>
        <Route path="*" element={<NotFound />} />
      </Routes>
    </Router>
  );
}

export default App;
