import {LoginPage} from "../pageObjects/LoginPageClass";

describe("The Login Page", () => {
    it("Logged in", () => {
        new LoginPage().doLogin();
    })
})