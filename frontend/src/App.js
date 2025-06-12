import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './App.css';

function App() {
  const [products, setProducts] = useState([]);
  const [cart, setCart] = useState([]);
  const [categories, setCategories] = useState([]);
  const [selectedCategory, setSelectedCategory] = useState('');
  const [search, setSearch] = useState('');
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [user, setUser] = useState(null);

  useEffect(() => {
    axios.get('/api/products')
      .then(res => setProducts(res.data))
      .catch(err => console.error(err));

    axios.get('/api/categories')
      .then(res => setCategories(res.data))
      .catch(err => console.error(err));
  }, []);

  const addToCart = (id) => {
    axios.post(`/api/cart/${id}`)
      .then(() => axios.get('/api/cart').then(res => setCart(res.data)))
      .catch(err => console.error(err));
  };

  const filteredProducts = products.filter(p => {
    return (
      (selectedCategory === '' || p.categoryId === selectedCategory) &&
      p.name.toLowerCase().includes(search.toLowerCase())
    );
  });

  const checkout = () => {
    const items = cart.map(c => ({ productId: c.product.id, quantity: c.quantity }));
    axios.post('/api/orders', items)
      .then(() => setCart([]))
      .catch(err => console.error(err));
  };

  const register = () => {
    axios.post('/api/auth/register', { username, password })
      .then(() => alert('Registered'))
      .catch(() => alert('Error registering'));
  };

  const login = () => {
    axios.post('/api/auth/login', { username, password })
      .then(() => {
        setUser(username);
        setUsername('');
        setPassword('');
      })
      .catch(() => alert('Invalid credentials'));
  };

  return (
    <div className="App">
      <header>
        <img src="/logo.png" className="logo" alt="logo" />
        <h1>Myntra Clone</h1>
      </header>
      <div className="auth">
        {user ? (
          <p>Logged in as {user}</p>
        ) : (
          <>
            <input placeholder="Username" value={username} onChange={e => setUsername(e.target.value)} />
            <input placeholder="Password" type="password" value={password} onChange={e => setPassword(e.target.value)} />
            <button onClick={login}>Login</button>
            <button onClick={register}>Register</button>
          </>
        )}
      </div>
      <div className="filters">
        <select value={selectedCategory} onChange={e => setSelectedCategory(Number(e.target.value))}>
          <option value="">All</option>
          {categories.map(c => (
            <option key={c.id} value={c.id}>{c.name}</option>
          ))}
        </select>
        <input placeholder="Search" value={search} onChange={e => setSearch(e.target.value)} />
      </div>
      <div className="products">
        {filteredProducts.map(p => (
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
      {cart.length > 0 && <button onClick={checkout}>Checkout</button>}
    </div>
  );
}

export default App;
