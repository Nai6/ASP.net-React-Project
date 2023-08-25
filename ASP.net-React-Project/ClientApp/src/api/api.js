import axios from "axios";

const instance = axios.create({
    baseURL: 'http://localhost:5229/api',
})

export const authAPI = {
    login(data) {
        return instance.get(`user/login?Name=${data.userName}&password=${data.password}`)
    },
    registration(userData) {
        return instance.post(`registration?Name=${userData.userName}&Password=${userData.userPassword}`)
    },
    getUserByJWT(data) {
        return instance.get('user/jwt', {headers: {'authorization':data}})
    }
}

export const userAPI = {
    getUsers() {
        return instance.get('user')
    },

    getUserById(id) {
        return instance.get(`user/${id}`)
    }
}

export const goodsAPI = {
    getAllGoods() {
        return instance.get('good/get')
    },

    getGoodsById(id) {
        return instance.get(`good/${id}`)
    },

    postGood(good) {
        return instance.post(`good/add?Name=${good.Name}&Price=${good.Price}&Img=${good.Img}`)
    },

    putGood(good) {
        return instance.put(`good/update?Name=${good.Name}&Price=${good.Price}&Img=${good.Img}`)
    },

    removeGood(id) {
        return instance.delete(`good/remove/${id}`)
    }
}

export const cartAPI = {
    getAllCarts() {
        return instance.get('cart')
    },

    getCartItem(data) {
        return instance.get('cart/items', {headers: {'authorization':data}})
    },

    postCart(data) {
        return instance.post(`cart/add?UserId=${data.UserId}&GoodId=${data.GoodId}`, {headers: {'authorization':data}})
    },

    deleteItemFromCart(data) {
        return instance.delete(`remove/${data.id}`, {headers: {'authorization':data}})
    }
}