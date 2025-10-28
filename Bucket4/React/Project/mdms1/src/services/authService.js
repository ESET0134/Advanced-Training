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

const ZONE_USER = {
  name: 'ZoneAdmin',
  email: 'zone@mdms.com',
  password: 'zone123',
  role: 'zone',
  zone: 'Bangalore South',
};

export const authService = {
  init() {
    const stored = localStorage.getItem(STORAGE_KEY);

    try {
      const parsed = JSON.parse(stored);

      if (Array.isArray(parsed)) return;

      if (parsed && typeof parsed === 'object') {
        localStorage.setItem(STORAGE_KEY, JSON.stringify([parsed, ZONE_USER]));
        return;
      }
    } catch {
    }

    localStorage.setItem(
      STORAGE_KEY,
      JSON.stringify([DEFAULT_USER, ZONE_USER])
    );
  },

  login({ email, password, rememberMe }) {
    this.init();

    const users = JSON.parse(localStorage.getItem(STORAGE_KEY)) || [];
    const user = Array.isArray(users)
      ? users.find((u) => u.email === email && u.password === password)
      : null;

    if (user) {
      const storage = rememberMe ? localStorage : sessionStorage;
      storage.setItem(TOKEN_KEY, 'mock-token-12345');
      storage.setItem(CURRENT_USER_KEY, JSON.stringify(user));

      const logs = JSON.parse(localStorage.getItem('userLogs')) || [];
      logs.unshift({
        timestamp: new Date().toLocaleString(),
        user: user.name,
        email: user.email,
        zone: user.zone,
        status: 'Login Successful',
      });
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
    const users = JSON.parse(localStorage.getItem(STORAGE_KEY)) || [];
    const current = this.getCurrentUser();
    if (!current) return null;

    const updatedUsers = users.map((u) =>
      u.email === current.email
        ? {
            ...u,
            name: name ?? u.name,
            email: email ?? u.email,
            password: password ?? u.password,
          }
        : u
    );

    localStorage.setItem(STORAGE_KEY, JSON.stringify(updatedUsers));

    const updatedUser = updatedUsers.find((u) => u.email === current.email);
    localStorage.setItem(CURRENT_USER_KEY, JSON.stringify(updatedUser));
    sessionStorage.setItem(CURRENT_USER_KEY, JSON.stringify(updatedUser));

    return updatedUser;
  },
};

authService.init();
