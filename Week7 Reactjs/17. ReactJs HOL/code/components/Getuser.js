import React, { Component } from 'react';

class Getuser extends Component {
  constructor() {
    super();
    this.state = {
      user: null
    };
  }

  async componentDidMount() {
    try {
      const res = await fetch('https://api.randomuser.me/');
      const data = await res.json();
      this.setState({ user: data.results[0] });
    } catch (error) {
      console.error('Error fetching user:', error);
    }
  }

  render() {
    const { user } = this.state;

    return (
      <div style={{ textAlign: 'center', marginTop: '50px' }}>
        {user ? (
          <>
            <h2>Mr {user.name.first} {user.name.last}</h2>
            <img src={user.picture.large} alt="user" style={{ borderRadius: '10px' }} />
          </>
        ) : (
          <p>Loading user...</p>
        )}
      </div>
    );
  }
}

export default Getuser;
