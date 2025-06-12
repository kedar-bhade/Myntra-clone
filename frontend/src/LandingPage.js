import React from 'react';
import { Link } from 'react-router-dom';
import './LandingPage.css';

function LandingPage() {
  return (
    <div className="landing">
      <header className="landing-header">
        <img src="/logo.png" className="logo" alt="logo" />
        <h1>Welcome to Myntra Clone</h1>
        <p>Your one stop shop for fashion</p>
        <div className="landing-links">
          <Link to="/login">Login</Link>
          <Link to="/register">Register</Link>
          <Link to="/shop" className="shop-btn">Shop Now</Link>
        </div>
      </header>
    </div>
  );
}

export default LandingPage;
