const expect = require('chai').expect;
const assert = require('chai').assert;
const PaymentPackage = require('./Payment Package');

describe('PaymentPackage', function() {

    it('should test if first parameter is a number', () => {        
        assert.throws(() => new PaymentPackage(1, 2),'Name must be a non-empty string' )
    });

    it('should test if first parameter is an empty string', () => {       
        assert.throws(() => new PaymentPackage('', 2),'Name must be a non-empty string' )
    });

    it('should test if first parameter is a string', () => {
        let obj = new PaymentPackage('test', 2);       
        assert.equal('test', obj.name);
    });

    it('should test if first parameter is a string and is changed', () => {
        let obj = new PaymentPackage('test', 2);       
        assert.equal('newName', obj.name = 'newName');
    });

    it('should test if second parameter is a string', () => {       
        assert.throws(() => new PaymentPackage('test', 'test'),'Value must be a non-negative number');
    });

    it('should test if second parameter is a negative number', () => {     
        assert.throws(() => new PaymentPackage('test', -2),'Value must be a non-negative number');
    });

    it('should test if second parameter is a positive number', () => {
        let obj = new PaymentPackage('test', 2);
       assert.equal(2, obj.value);
    });

    it('should test if second parameter is a positive number and is changed', () => {
        let obj = new PaymentPackage('test', 2);
        assert.equal(3, obj.value = 3);
    });

    it('should test if VAT is a default value', () => {
        let obj = new PaymentPackage('test', 2);
        assert.equal(20, obj.VAT);
    });

    it('should test if VAT is not a number', () => {
        let obj = new PaymentPackage('test', 2);        
        assert.throws(() => obj.VAT = 'VAT', 'VAT must be a non-negative number');
    });

    it('should test if VAT is a negative number', () => {
        let obj = new PaymentPackage('test', 2);        
        assert.throws(() => obj.VAT = -20, 'VAT must be a non-negative number');
    });

    it('should test if VAT is a positive number and is changed', () => {
        let obj = new PaymentPackage('test', 2);
        assert.equal( 10, obj.VAT = 10);
    });

    it('should test if active is a default value', () => {
        let obj = new PaymentPackage('a', 1);
        assert.equal(true, obj.active)
    });

    it('should test if active is a string', () => {
        let obj = new PaymentPackage('test', 2);       
        assert.throws(() => obj.active = 'test', 'Active status must be a boolean');
    });

    it('should test if active is set to false', () => {
        let obj = new PaymentPackage('test', 2);  
        assert.equal(false, obj.active = false);
    });

    it("test toString", () => {
        let obj = new PaymentPackage('HR Services', 1500);       
        assert.equal(obj.toString(), 'Package: HR Services\n- Value (excl. VAT): 1500\n- Value (VAT 20%): 1800');
    });
    it("test toString", () => {
        let obj = new PaymentPackage('HR Services', 1500);
        obj.active = false;
        assert.equal(obj.toString(),'Package: HR Services (inactive)\n- Value (excl. VAT): 1500\n- Value (VAT 20%): 1800');
    });
    it("test toString", () => {
        let obj = new PaymentPackage('HR Services', 1500);
        obj.VAT = 0;
        assert.equal(obj.toString(), 'Package: HR Services\n- Value (excl. VAT): 1500\n- Value (VAT 0%): 1500');
    });
    it("test toString", () => {
        let obj = new PaymentPackage('HR Services', 0);
        obj.VAT = 0;
        assert.equal(obj.toString(),'Package: HR Services\n- Value (excl. VAT): 0\n- Value (VAT 0%): 0');
    });
});