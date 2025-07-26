import React from 'react';
import Post from './Post';

class Posts extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      posts: [],
      hasError: false
    };
  }

  loadPosts = () => {
    fetch('https://jsonplaceholder.typicode.com/posts')
      .then((res) => res.json())
      .then((data) => {
        const postObjects = data.map(post => new Post(post.id, post.title, post.body));
        this.setState({ posts: postObjects });
      })
      .catch((err) => {
        console.error("Fetch error:", err);
      });
  }

  componentDidMount() {
    this.loadPosts();
  }

  componentDidCatch(error, info) {
    alert("An error occurred: " + error.message);
    this.setState({ hasError: true });
  }

  render() {
    if (this.state.hasError) {
      return <h2 style={{ color: 'red' }}>Something went wrong while loading posts.</h2>;
    }

    return (
      <div>
        <h2>Post List</h2>
        {this.state.posts.map((post) => (
          <div key={post.id} style={{ marginBottom: '1.5rem' }}>
            <h3>{post.title}</h3>
            <p>{post.body}</p>
          </div>
        ))}
      </div>
    );
  }
}

export default Posts;
