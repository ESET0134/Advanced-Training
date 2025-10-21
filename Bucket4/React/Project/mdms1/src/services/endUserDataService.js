export const endUserDataService = {
  getUserData() {
    return {
      userId: 1,
      name: 'Shruti',
      zone: 'Bangalore North',
      consumption: [
        { date: '2025-10-01', kwh: 320 },
        { date: '2025-10-05', kwh: 410 },
        { date: '2025-10-10', kwh: 380 },
        { date: '2025-10-15', kwh: 450 },
        { date: '2025-10-20', kwh: 300 },
        { date: '2025-10-25', kwh: 350 },
        { date: '2025-10-30', kwh: 420 },
        { date: '2025-11-05', kwh: 460 },
        { date: '2025-11-10', kwh: 430 },
        { date: '2025-11-15', kwh: 390 },
        { date: '2025-11-20', kwh: 470 },
        { date: '2025-11-25', kwh: 410 },
        { date: '2025-11-28', kwh: 440 },
      ],
      billing: {
        totalUnits: 4780,
        ratePerKwh: 5.5,
        dueDate: '2025-11-30',
        lastPaymentDate: '2025-10-10',
        lastPaymentAmount: 1200,
        outstandingBalance: 120,
      },
      payments: [
        {
          date: "2025-11-28",
          billAmount: 2350,
          paidAmount: 0,
          status: "Pending",
          receiptId: null,
        },
        {
          date: "2025-10-10",
          billAmount: 1200,
          paidAmount: 1200,
          status: "Paid",
          receiptId: "RCPT1023",
        },
        {
          date: "2025-10-20",
          billAmount: 1000,
          paidAmount: 1000,
          status: "Paid",
          receiptId: "RCPT1025",
        },
        {
          date: "2025-09-10",
          billAmount: 1150,
          paidAmount: 1150,
          status: "Paid",
          receiptId: "RCPT1019",
        },
        {
          date: "2025-09-20",
          billAmount: 1300,
          paidAmount: 1300,
          status: "Paid",
          receiptId: "RCPT1021",
        },
        {
          date: "2025-08-10",
          billAmount: 1230,
          paidAmount: 1230,
          status: "Paid",
          receiptId: "RCPT1015",
        },
      ],
    };
  },

  getDashboardStats() {
    const data = this.getUserData();
    const totalKwh = data.consumption.reduce((sum, d) => sum + d.kwh, 0);
    const averageKwh = (totalKwh / data.consumption.length).toFixed(0);
    const due = new Date(data.billing.dueDate).toLocaleDateString('en-US', {
      day: 'numeric',
      month: 'short',
    });
    const paid = new Date(data.billing.lastPaymentDate).toLocaleDateString(
      'en-US',
      {
        day: 'numeric',
        month: 'short',
      }
    );

    const currentBill = `₹${(averageKwh * data.billing.ratePerKwh).toFixed(0)} Due on ${due}`;

    return {
      currentConsumption: `${averageKwh} kWh`,
      currentBill,
      outstanding: `₹${data.billing.outstandingBalance} Pending`,
      lastPayment: `Paid ₹${data.billing.lastPaymentAmount} on ${paid}`,
    };
  },

  getChartData(filter = 'month') {
    const data = this.getUserData().consumption;
    if (filter === 'day') {
      return [
        { name: '12 AM', kwh: 15 },
        { name: '4 AM', kwh: 25 },
        { name: '8 AM', kwh: 35 },
        { name: '12 PM', kwh: 70 },
        { name: '4 PM', kwh: 50 },
        { name: '8 PM', kwh: 80 },
      ];
    }
    if (filter === 'week') {
      return data.slice(-7).map((d) => ({
        name: new Date(d.date).toLocaleDateString('en-US', {
          month: 'short',
          day: 'numeric',
        }),
        kwh: d.kwh,
      }));
    }
    return data.map((d) => ({
      name: new Date(d.date).toLocaleDateString('en-US', {
        month: 'short',
        day: 'numeric',
      }),
      kwh: d.kwh,
    }));
  },

  getConsumptionData() {
    return this.getUserData().consumption;
  },

  getBills() {
    const data = this.getUserData();
    const bills = data.payments.map((p) => {
      const month = new Date(p.date).toLocaleString('en-US', { month: 'short' });
      const year = new Date(p.date).getFullYear();
      const dueDateObj = new Date(p.date);
      dueDateObj.setMonth(dueDateObj.getMonth() + 1, 0);
      return {
        month,
        year,
        amount: p.billAmount,
        dueDate: dueDateObj.toLocaleDateString('en-US', {
          day: '2-digit',
          month: 'short',
        }),
        status: p.status,
      };
    });

    const currentDue = new Date(data.billing.dueDate);
    const currentMonth = currentDue.toLocaleString('en-US', { month: 'short' });
    const currentYear = currentDue.getFullYear();
    if (!bills.some((b) => b.month === currentMonth && b.year === currentYear)) {
      bills.push({
        month: currentMonth,
        year: currentYear,
        amount: (data.billing.totalUnits * data.billing.ratePerKwh).toFixed(2),
        dueDate: new Date(currentDue.getFullYear(), currentDue.getMonth() + 1, 0).toLocaleDateString('en-US', {
          day: '2-digit',
          month: 'short',
        }),
        status: "Pending",
      });
    }

    return bills;
  },
};
