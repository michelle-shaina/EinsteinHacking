﻿using EinsteinHacking.Models;
using System;

namespace EinsteinHacking.Services
{
    public class AlertState
    {
        AlertModel alert = new AlertModel();
        public event Action OnChange;

        public void SetAlert(string alertState)
        {
            switch (alertState)
            {
                case "true":
                    alert.AlertTitle = "Alert: ";
                    alert.AlertType = "success";
                    alert.AlertMessage = "Congratulations. The password is correct!";
                    break;
                case "false":
                    alert.AlertTitle = "Alert: ";
                    alert.AlertType = "danger";
                    alert.AlertMessage = "The password is not correct. Try Again!";
                    break;
                case "completed":
                    alert.AlertTitle = "Alert: ";
                    alert.AlertType = "warning";
                    alert.AlertMessage = "You have already completed the Challenge. Try another one!";
                    break;
                case "neutral":
                    alert.AlertTitle = "";
                    alert.AlertType = "";
                    alert.AlertMessage = "";
                    break;
                default:
                    alert.AlertTitle = "";
                    alert.AlertType = "";
                    alert.AlertMessage = "";
                    break;
            }
        }

        public AlertModel GetAlert()
        {
            return alert;
        }
    }
}
