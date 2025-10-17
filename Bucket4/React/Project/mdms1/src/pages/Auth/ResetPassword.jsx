import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import Header from '../../components/layout/Header/Header';
import { authService } from '../../services/authService';

export default function ResetPassword() {
  const navigate = useNavigate();
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [email, setEmail] = useState('');

  useEffect(() => {
    const email = sessionStorage.getItem('reset_email');
    if (!email) {
      navigate('/forgot-password', { replace: true });
    } else {
      setEmail(email);
    }
  }, [navigate]);

  const handleSubmit = (e) => {
    e.preventDefault();
    if (password !== confirmPassword) {
      alert('Passwords do not match!');
      return;
    }

    const user = JSON.parse(localStorage.getItem('mdms_auth_user'));
    if (user && user.email === email) {
      authService.updateProfile({ password });
      alert('Password updated successfully! Please login again.');
      localStorage.removeItem('reset_email');
      navigate('/');
    } else {
      alert('Something went wrong. Please try again.');
    }
  };

  return (
    <div className="w-screen min-h-screen flex flex-col">
      <Header />
      <div className="flex flex-1 justify-center items-center bg-gray-100 dark:bg-gray-900 p-6">
        <form
          onSubmit={handleSubmit}
          className="w-full max-w-sm text-center bg-white dark:bg-gray-800 p-6 rounded-lg border border-gray-200 dark:border-gray-700"
        >
          <h2 className="text-xl mb-4 text-black dark:text-white">Reset Password</h2>

          <input
            type="password"
            placeholder="New Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            className="w-full mb-4 px-3 py-2 border border-gray-300 rounded-2xl text-black dark:bg-gray-700 dark:text-white"
            required
          />

          <input
            type="password"
            placeholder="Confirm New Password"
            value={confirmPassword}
            onChange={(e) => setConfirmPassword(e.target.value)}
            className="w-full mb-4 px-3 py-2 border border-gray-300 rounded-2xl text-black dark:bg-gray-700 dark:text-white"
            required
          />

          <button
            type="submit"
            onClick={() => navigate('/')}
            className="border border-black px-6 text-black py-1 rounded-full bg-transparent dark:text-white dark:border-white"
          >
            Update Password
          </button>
        </form>
      </div>
    </div>
  );
}
