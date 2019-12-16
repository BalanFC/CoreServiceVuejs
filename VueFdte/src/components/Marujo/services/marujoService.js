import axios from 'axios';

const client = axios.create({
  baseURL: 'https://localhost:44393/api/marujo',
  json: true
});

export default {
  async execute (method, resource, data) {
    return client({
      method,
      url: resource,
      data,
    }).then(req => {
      return req.data
    })
  },
  getAll () {
    return this.execute('get', '/GetMarujos')
  },
  get (id) {
    return this.execute('get', `/GetMarujo/${id}`)
  },
  create (data) {
    return this.execute('post', '/AddMarujo', data)
  },
  update (data) {
    return this.execute('post', `/UpdateMarujo`, data)
  },
  delete (id) {
    return this.execute('delete', `/DeleteMarujo/${id}`)
  }
}
