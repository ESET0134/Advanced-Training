import React, { useEffect, useState } from "react";
import Header from "../../components/layout/Header/Header";
import EndUserSidebar from "../../components/layout/Sidebar/EndUserSidebar";

const Logs = () => {
  const [logs, setLogs] = useState([]);
  const [filter, setFilter] = useState("all");

  useEffect(() => {
    const storedLogs = JSON.parse(localStorage.getItem("userLogs")) || [];
    setLogs(storedLogs);
  }, []);

  const clearLogs = () => {
    localStorage.removeItem("userLogs");
    setLogs([]);
  };

  const filteredLogs = logs.filter((log) => {
    if (filter === "all") return true;
    return log.status === filter;
  });

  return (
    <div className="min-h-screen w-screen bg-gray-50 dark:bg-gray-900">
      <Header />
      <div className="flex">
        <EndUserSidebar />
        <main className="flex-1 p-6">
          <div className="max-w-6xl mx-auto">
            <div className="flex justify-between items-center mb-6">
              <h2 className="text-2xl font-bold text-gray-900 dark:text-white">
                User Activity Logs
              </h2>
              <div className="flex gap-3">
                <select
                  value={filter}
                  onChange={(e) => setFilter(e.target.value)}
                  className="border rounded-lg px-3 py-2 text-gray-700 dark:text-gray-900 bg-white focus:outline-none"
                >
                  <option value="all">All</option>
                  <option value="Login Successful">Successful</option>
                  <option value="Login Failed">Failed</option>
                </select>
                <button
                  onClick={clearLogs}
                  className="bg-red-500 text-white px-4 py-2 rounded-lg hover:bg-red-600 transition"
                >
                  Clear Logs
                </button>
              </div>
            </div>

            {/* Logs Table */}
            <div className="overflow-x-auto rounded-lg shadow border border-gray-200 dark:border-gray-700 bg-white dark:bg-gray-800">
              <table className="min-w-full">
                <thead className="bg-blue-50 dark:bg-gray-700">
                  <tr>
                    <th className="py-3 px-4 text-left text-sm font-semibold text-gray-600 dark:text-gray-200">
                      Timestamp
                    </th>
                    <th className="py-3 px-4 text-left text-sm font-semibold text-gray-600 dark:text-gray-200">
                      User
                    </th>
                    <th className="py-3 px-4 text-left text-sm font-semibold text-gray-600 dark:text-gray-200">
                      Email
                    </th>
                    <th className="py-3 px-4 text-left text-sm font-semibold text-gray-600 dark:text-gray-200">
                      Zone
                    </th>
                    <th className="py-3 px-4 text-left text-sm font-semibold text-gray-600 dark:text-gray-200">
                      Status
                    </th>
                  </tr>
                </thead>
                <tbody>
                  {filteredLogs.length > 0 ? (
                    filteredLogs.map((log, index) => (
                      <tr
                        key={index}
                        className={`border-b dark:border-gray-700 hover:bg-gray-50 dark:hover:bg-gray-700 transition ${
                          log.status === "Login Successful"
                            ? "text-green-600"
                            : "text-red-600"
                        }`}
                      >
                        <td className="py-2 px-4 text-sm">{log.timestamp}</td>
                        <td className="py-2 px-4 text-sm">{log.user}</td>
                        <td className="py-2 px-4 text-sm">{log.email}</td>
                        <td className="py-2 px-4 text-sm">{log.zone}</td>
                        <td className="py-2 px-4 text-sm">{log.status}</td>
                      </tr>
                    ))
                  ) : (
                    <tr>
                      <td
                        colSpan="5"
                        className="text-center text-gray-500 dark:text-gray-400 py-6 text-sm"
                      >
                        No logs available.
                      </td>
                    </tr>
                  )}
                </tbody>
              </table>
            </div>

            {/* Summary */}
            <div className="mt-6 text-gray-600 dark:text-gray-300 text-sm">
              <p>
                🕒 Total Logins Recorded: <strong>{logs.length}</strong>
              </p>
              {logs.length > 0 && (
                <p>
                  Last Login:{" "}
                  <strong>{new Date(logs[0].timestamp).toLocaleString()}</strong>
                </p>
              )}
            </div>
          </div>
        </main>
      </div>
    </div>
  );
};

export default Logs;
