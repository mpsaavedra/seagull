# POS Management system

![Seagull POS](../../../docs/images/pos-cashier.png)

This is a **Point Of Sale** included in the **Seagull SaaS System** currently 
under development, but in order to correctly understand how it works is better 
to begin to understand the flow of products in the system, how a product will be moved
around the system.

Possible the main entry point in the entire system is ``Warehouse``, because is
where ``Products`` are first delivered. Commonly through a ``Purchase`` that comes
with a form of ``Invoice`` even though in some cases a ``Purchase`` could be made
directly to a private ``Supplier`` internally the receptor MUST create a fictional
``Invoice`` so the system could handle the information the same way no matter the
supplier.

So, when the ``Product`` is received in it passes to be registered into the system
as part of a ``Purchase``. This step place the newly received product into a form
of standby status. This status is to process or any other task required, like
classification, processing, etc. Then it passes to be a real ``Product`` in the
``Warehouse`` shelfs, from this point on they could be distributed, sold, or any
other convenient operation.

There are different types of operations:

* **Sale**: Direct sale from the warehouse to a client
* **Deliver**: The product has been temporally retain and is distributed to a client, thats has already made some type of reservation or pre-sale.
* **Transfer**: The product is transfer to another ``Stand`  that is part of the company.

Once any of this operations are made with a product the proces is almost the same
a deduction is made from the ``Warehouse`` stock. In cases of sales and delivers,
 products are internally moved to the fields related with those operations. By
 using this mechanism we could keep a track of where product are located but they are no longer part of the main warehouse stock.

 In case of transfer products passes to be part of the ``Stand`` stock where are
 managed by them.

 ## Payments

 Because a sale, purchase or any other operation could be made in different currencies the
 payment is capable to make those registers in different currencies using the ``Money``
 valueobject this allow to acccept in a single purchase different payment types, the main
 goal is to allow the customer to pay a single purchase using different payment methods.
 Another aspect to note is that the payment could be made on different stages, or steps.

 ## Shipping

 Shipping has been centralized in a single entity because in a single shipping should be
 possible to deliver purchases from different entities, even when the products MUST have
 entrance throught the warehouse, the shipping provider could charge a single shipping trip
 for different Warehouses or POS, otherwise s necessare to make more than one shipping order
 which could be not to easy for user and allow the possibility to errors and most of all
 the shipping order number could be repeated.