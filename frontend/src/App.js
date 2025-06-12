import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './App.css';

function App() {
  const [products, setProducts] = useState([]);
  const [cart, setCart] = useState([]);

  useEffect(() => {
    axios.get('/api/products')
      .then(res => setProducts(res.data))
      .catch(err => console.error(err));
  }, []);

  const addToCart = (id) => {
    axios.post(`/api/cart/${id}`)
      .then(() => axios.get('/api/cart').then(res => setCart(res.data)))
      .catch(err => console.error(err));
  };

  return (
    <div className="App">
      <header>
        <img src="/logo.png" className="logo" alt="logo" />
        <h1>Myntra Clone</h1>
      </header>
      <div className="products">
        {products.map(p => (
          <div key={p.id} className="product">
            <img src={p.imageUrl} alt={p.name} />
            <h3>{p.name}</h3>
            <p>{p.description}</p>
            <p>${p.price}</p>
            <button onClick={() => addToCart(p.id)}>Add to Cart</button>
          </div>
        ))}
      </div>
      <h2>Cart</h2>
      <ul>
        {cart.map(c => (
          <li key={c.product.id}>{c.product.name} - qty {c.quantity}</li>
        ))}
      </ul>
    </div>
  );
}

export default App;
