# Meter Data Management System (MDMS)

## Overview

The **Meter Data Management System (MDMS)** is a full-featured, role-based **React.js** application designed for managing and monitoring electricity meter data.  
It supports three levels of access — **End User**, **Zone Level User**, and **Enterprise Level User** — each with tailored dashboards and functionalities.

This project serves as a **learning platform** to explore **Advanced React concepts**, including custom hooks, API integration, reusable components, authentication, logging, localization, and Tailwind-based responsive UI.

---

## Purpose

The MDMS provides a **centralized system** for electricity data management and analytics.  
It also demonstrates modern **React architecture** and **real-world project standards** suitable for enterprise-level applications.

---

## User Roles & Core Features

### End Users

- View personal electricity consumption.
- Visual charts for daily/weekly/monthly usage.
- Access and download bills.
- View payment history and outstanding balance.
- Manage profile, photo, and password.
- Configure notification preferences.
- View historical meter readings
- Compare usage with previous periods
- Alerts for abnormal usage.
- Log all user interactions.

---

### Zone-Level Users

- Zone-wide dashboard with total consumption and active meters.
- Alerts for abnormal consumption patterns.
- Manage meters: Add, Edit, Deactivate, Import/Export.
- Manage end users and reset passwords.
- Generate zone-specific reports.
- Configure zone-level notifications.

---

### Enterprise-Level Users

- Global dashboard with multi-zone analytics and KPIs.
- High-level alerts for critical issues
- Manage zones and assign administrators.
- Manage all meters and users across zones.
- Configure enterprise-level policies, data retention, and auto-logout timer.
- Full **Audit Logs** system with PDF/CSV export.
- Localization, currency, and timezone customization.

---

## Technical Highlights

| Category         | Technology / Library          |
| ---------------- | ----------------------------- |
| Frontend         | React.js (Vite)               |
| Styling          | Tailwind CSS                  |
| Charts           | Recharts                      |
| State Management | React Hooks / Context API     |
| Routing          | React Router DOM              |
| Localization     | React-i18next                 |
| PDF Export       | jsPDF + jsPDF-AutoTable       |
| Authentication   | LocalStorage & SessionStorage |
| Code Quality     | ESLint + Prettier             |
| Theme            | Light/Dark Mode via Tailwind  |

---

## Advanced React Concepts Implemented

- **Role-Based Routing** using React Router v6
- **Custom Hooks** for API logic and data fetching
- **Context + Reducer pattern** for state management
- **Localization and Dark Mode support**
- **Complete logging and audit trail system**
- **Reusable UI components and layout system**

---

## Folder Structure

    src/
    ├── components/
    │ ├── layout/
    │   ├── Header/
    │   ├── Sidebar/
    │   ├── ProtectedRoute.jsx
    |   └── UtilityLayout.jsx
    ├── pages/
    │ ├── Auth/
    │ ├── EndUser/
    │ ├── Zone/
    │ ├── Enterprise/
    │ └── Utility/
    ├── hooks/
    ├── i18n/
    ├── services/
    └── assets/
    └── App.jsx
    └── index.css
    └── main.jsx
    └── App.css

---

## Logging & Audit Trail

- Each **login**, **logout**, **password reset**, and **page visit** is logged in `localStorage.userLogs`.
- **End Users** can view only their logs in their Logs tab.
- **Enterprise Users** can view and export all logs in Enterprise View via the Audit Logs page.

---

## Mock Data Initialization

MDMS uses a built-in mock data service via `authService.init()`.  
On first run, it auto-creates three user roles:

| Role             | Email                 | Password        |
| ---------------- | --------------------- | --------------- |
| End User         | `enduser@mdms.com`    | `mdms123`       |
| Zone Admin       | `zone@mdms.com`       | `zone123`       |
| Enterprise Admin | `enterprise@mdms.com` | `enterprise123` |

The mock data is stored in:

    localStorage['mdms_auth_user']

---

## Running the Project Locally

Follow these steps to set up and run the project on your local machine.

---

### Clone the Repository

```bash
git clone https://github.com/ESET0134/Advanced-Training.git
                        OR
git clone git@github.com:ESET0134/Advanced-Training.git
cd .\Bucket4\React\Project\mdms1\
```

### Install Dependencies

Make sure you have Node.js v16+ installed, then run:

```bash
npm install
```

If you are setting up from scratch, install the dependencies manually:

```bash
npm install react react-dom react-router-dom
npm install recharts
npm install jspdf jspdf-autotable
npm install react-i18next i18next
npm install lucide-react
npm install axios
```

### Setup Tailwind CSS

If Tailwind is not already configured, run:

```bash
npm install -D tailwindcss postcss autoprefixer
npm install -D tailwindcss@3.4.17
npx tailwindcss init -p
```

Then edit your tailwind.config.js file as follows:

```js
export default {
  content: ['./index.html', './src/**/*.{js,ts,jsx,tsx}'],
  theme: {
    extend: {},
  },
  plugins: [],
};
```

Add Tailwind directives to your src/index.css:

```bash
@tailwind base;
@tailwind components;
@tailwind utilities;
```

### Run the Development Server

```bash
npm run dev
```

Then visit the app in your browser:
👉 http://localhost:5173

### Available Scripts

| Command         | Description                           |
| --------------- | ------------------------------------- |
| npm run dev     | Runs the development server           |
| npm run build   | Builds the app for production         |
| npm run preview | Previews the production build locally |
| npm run lint    | Runs ESLint for code checking         |

---

## Contributors

**Shruti Singhania**

Developer & Architect — Designed and implemented MDMS as a full-featured React learning and demonstration project.
