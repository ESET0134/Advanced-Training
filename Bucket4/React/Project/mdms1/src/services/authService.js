const STORAGE_KEY = 'mdms_auth_user';
const CURRENT_USER_KEY = 'mdms_current_user';
const TOKEN_KEY = 'mdms_token';

const DEFAULT_USER = {
  name: 'Shruti',
  email: 'enduser@mdms.com',
  password: 'mdms123',
  role: 'enduser',
  zone: 'Bangalore North',
};

export const authService = {
  init() {
    const stored = localStorage.getItem(STORAGE_KEY);
    if (!stored) {
      localStorage.setItem(STORAGE_KEY, JSON.stringify(DEFAULT_USER));
    }
  },

  login({ email, password, rememberMe }) {
  this.init();
  const user = JSON.parse(localStorage.getItem(STORAGE_KEY)) || DEFAULT_USER;

  if (email === user.email && password === user.password) {
    const storage = rememberMe ? localStorage : sessionStorage;
    storage.setItem(TOKEN_KEY, 'mock-token-12345');
    storage.setItem(CURRENT_USER_KEY, JSON.stringify(user));

    const logs = JSON.parse(localStorage.getItem('userLogs')) || [];
    const newLog = {
      timestamp: new Date().toLocaleString(),
      user: user.name || 'Unknown User',
      email: user.email || '-',
      zone: user.zone || '-',
      status: 'Login Successful',
    };
    logs.unshift(newLog);
    localStorage.setItem('userLogs', JSON.stringify(logs));

    return { success: true, user };
  }

  const logs = JSON.parse(localStorage.getItem('userLogs')) || [];
  logs.unshift({
    timestamp: new Date().toLocaleString(),
    user: 'Unknown',
    email,
    zone: '-',
    status: 'Login Failed',
  });
  localStorage.setItem('userLogs', JSON.stringify(logs));

  return { success: false, message: 'Invalid credentials' };
},


  logout() {
    localStorage.removeItem(TOKEN_KEY);
    localStorage.removeItem(CURRENT_USER_KEY);
    sessionStorage.removeItem(TOKEN_KEY);
    sessionStorage.removeItem(CURRENT_USER_KEY);
  },

  isAuthenticated() {
    return (
      !!localStorage.getItem(TOKEN_KEY) || !!sessionStorage.getItem(TOKEN_KEY)
    );
  },

  getCurrentUser() {
    const localUser = localStorage.getItem(CURRENT_USER_KEY);
    const sessionUser = sessionStorage.getItem(CURRENT_USER_KEY);
    return JSON.parse(localUser || sessionUser || 'null');
  },

  updateProfile({ name, email, password }) {
    const user = JSON.parse(localStorage.getItem(STORAGE_KEY)) || DEFAULT_USER;

    const updated = {
      ...user,
      name: name ?? user.name,
      email: email ?? user.email,
      password: password ?? user.password,
    };

    // Always keep master user info in localStorage
    localStorage.setItem(STORAGE_KEY, JSON.stringify(updated));

    // If logged in, update current user in both storages
    if (localStorage.getItem(CURRENT_USER_KEY)) {
      localStorage.setItem(CURRENT_USER_KEY, JSON.stringify(updated));
    }
    if (sessionStorage.getItem(CURRENT_USER_KEY)) {
      sessionStorage.setItem(CURRENT_USER_KEY, JSON.stringify(updated));
    }

    return updated;
  },
};

// Initialize default user on module load
authService.init();
