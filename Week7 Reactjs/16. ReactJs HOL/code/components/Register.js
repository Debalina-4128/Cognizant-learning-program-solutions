import React, { useState } from 'react';
import './Register.css';

const Register = () => {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const validate = () => {
    if (name.length < 5) {
      alert('Full Name must be 5 characters long!');
      return false;
    }

    if (!email.includes('@') || !email.includes('.')) {
      alert('Email is not valid!');
      return false;
    }

    if (password.length < 8) {
      alert('Password must be 8 characters long!');
      return false;
    }

    return true;
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (validate()) {
      alert('Registration Successful!');
      // You can reset or send data to a server here
      setName('');
      setEmail('');
      setPassword('');
    }
  };

  return (
    <div className="register-container">
      <h2>Register Here!!!</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Name: </label>
          <input type="text" value={name}
            onChange={(e) => setName(e.target.value)} required />
        </div>
        <div>
          <label>Email: </label>
          <input type="email" value={email}
            onChange={(e) => setEmail(e.target.value)} required />
        </div>
        <div>
          <label>Password: </label>
          <input type="password" value={password}
            onChange={(e) => setPassword(e.target.value)} required />
        </div>
        <button type="submit">Submit</button>
      </form>
    </div>
  );
};

export default Register;
