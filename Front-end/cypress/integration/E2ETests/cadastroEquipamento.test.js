describe('Cadastro de equipamento', () => {

    beforeEach(() => {
        cy.visit("http://localhost:3000")
    })

    // it('Deve cadastrar um novo equipamento', () => {
    //     cy.get('.cabecalhoPrincipal-nav-login').should('exist');
    //     cy.get('.cabecalhoPrincipal-nav-login').click();

    //     cy.get('.input__login').first().type("paulo@email.com");
    //     cy.get('.input__login').last().type("123456789");

    //     cy.get('#btn__login').click();

    //     cy.get('#nomePatrimonio').type('Patrimônio teste')
    //     cy.get('input[type=checkbox').check()

    //     cy.get('input[type=file]').first().selectFile('src/assets/tests/equipamento.jpeg');
    //     cy.wait(3000);

    //     cy.get('input[type=file]').last().selectFile('src/assets/tests/teste.png');
    //     cy.get('button[type=submit]').click();        
    // })

    it('Deve excluir um equipamento específico', () => {
        cy.get('.cabecalhoPrincipal-nav-login').should('exist');
        cy.get('.cabecalhoPrincipal-nav-login').click();

        cy.get('.input__login').first().type("paulo@email.com");
        cy.get('.input__login').last().type("123456789");

        cy.get('#btn__login').click();

        cy.wait(2000)
    
        cy.get('.excluir').last().click();
    })
})