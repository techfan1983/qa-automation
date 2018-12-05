import {Config} from "../common/ConfigClass";
import {Common} from "./CommonClass";

export class LoginPage {
    navigate = () => cy.visit('/Security/Login');
    loginEmail = () => cy.get('#loginEmail');
    loginPassword = () => cy.get('#loginPassword');
    loginButton = () => cy.get('button');
    untilMessage1IsHidden = () => cy.contains("*", "Logging in, please wait...", Config.pageInteractionTimeoutWrapped).should("not.be.visible");
    untilMessage2IsHiddren = () => cy.contains("*", "Logging in", Config.pageInteractionTimeoutWrapped).should("not.be.visible");

    doLogin(){
        let loginEmail = Config.loginEmail;
        let loginPassword = Config.loginPassword;

        this.navigate();
        this.loginEmail().type(loginEmail);
        this.loginPassword().type(loginPassword);
        this.loginButton().click();
        this.untilMessage1IsHidden();
        this.untilMessage2IsHiddren();
        Common.WaitForSpinnerToOff();
    }
}