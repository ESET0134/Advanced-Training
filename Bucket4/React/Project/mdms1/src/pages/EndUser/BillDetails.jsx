import React from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import Header from '../../components/layout/Header/Header';
import EndUserSidebar from '../../components/layout/Sidebar/EndUserSidebar';
import { endUserDataService } from '../../services/endUserDataService';

export default function BillDetails() {
const { receiptId } = useParams();
const navigate = useNavigate();
const data = endUserDataService.getUserData();

// find matching bill
const bill = data.payments.find((p) => p.receiptId === receiptId) || data.payments.find((p) => p.status === 'Pending');

if (!bill) {
return (
<div>
<Header />
<div className="flex">
<EndUserSidebar />
<main className="flex-1 p-6">
<h2 className="text-xl font-semibold text-red-600">Bill Not Found</h2>
<button
onClick={() => navigate('/enduser/bills-payments')}
className="mt-4 px-4 py-2 border rounded"
>
Go Back
</button>
</main>
</div>
</div>
);
}

const monthYear = new Date(bill.date).toLocaleString('en-US', {
month: 'long',
year: 'numeric',
});

const dueDate = new Date(bill.date);
dueDate.setDate(dueDate.getDate() + 30);

return (
<div className="min-h-screen w-screen bg-gray-50 dark:bg-gray-900">
<Header />
<div className="flex">
<EndUserSidebar />
<main className="flex-1 p-6">
<div className="max-w-4xl mx-auto bg-white dark:bg-gray-800 border border-gray-200 dark:border-gray-700 rounded-lg p-6">
<button
onClick={() => navigate(-1)}
className="text-gray-600 hover:text-black dark:text-gray-300 mb-4"
>
← Back
</button>
<h1 className="text-2xl font-semibold mb-4 text-gray-900 dark:text-white">
Bill Details – {monthYear}
</h1>

{/* Summary Table */}
<table className="w-full mb-6 border border-gray-300 text-left text-gray-800 dark:text-gray-200">
<thead className="bg-gray-200 dark:bg-gray-700">
<tr>
<th className="px-4 py-2">Month</th>
<th className="px-4 py-2">Total Amount</th>
<th className="px-4 py-2">Due Date</th>
<th className="px-4 py-2">Status</th>
</tr>
</thead>
<tbody>
<tr>
<td className="border-t px-4 py-2">{monthYear}</td>
<td className="border-t px-4 py-2">₹{bill.billAmount}</td>
<td className="border-t px-4 py-2">
{dueDate.toLocaleDateString('en-US', {
day: '2-digit',
month: 'short',
year: 'numeric',
})}
</td>
<td className="border-t px-4 py-2">{bill.status}</td>
</tr>
</tbody>
</table>

{/* Details Table */}
<table className="w-full mb-6 border border-gray-300 text-left text-gray-800 dark:text-gray-200">
<thead className="bg-gray-200 dark:bg-gray-700">
<tr>
<th className="px-4 py-2">Date</th>
<th className="px-4 py-2">Reading</th>
<th className="px-4 py-2">Consumption</th>
<th className="px-4 py-2">Cost</th>
</tr>
</thead>
<tbody>
{bill.details.map((d, i) => (
<tr key={i}>
<td className="border-t px-4 py-2">{d.date}</td>
<td className="border-t px-4 py-2">{d.reading}</td>
<td className="border-t px-4 py-2">{d.consumption}</td>
<td className="border-t px-4 py-2">{d.cost}</td>
</tr>
))}
</tbody>
</table>

{/* Action Buttons */}
<div className="flex gap-3">
<button className="border border-gray-400 px-4 py-2 rounded hover:bg-gray-100">
Download PDF
</button>
<button
onClick={() => window.print()}
className="border border-gray-400 px-4 py-2 rounded hover:bg-gray-100"
>
Print Bill
</button>
<button className="border border-gray-400 px-4 py-2 rounded bg-green-500 text-white hover:bg-green-600">
Pay Now
</button>
</div>
</div>
</main>
</div>
</div>
);
}
