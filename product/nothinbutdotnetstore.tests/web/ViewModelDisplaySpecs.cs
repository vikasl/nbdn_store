<<<<<<< HEAD
 using System;
 using System.Collections.Generic;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdd.mocking.rhino;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.dto;
 using nothinbutdotnetstore.tasks;
 using nothinbutdotnetstore.web.application;
 using nothinbutdotnetstore.web.infrastructure;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
 {   
     public class ViewModelDisplaySpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
                                             ViewModelDisplay<IEnumerable<DepartmentItem>>>
         {
        
         }

         [Concern(typeof(ViewModelDisplay<IEnumerable<DepartmentItem>>))]
         public class when_observation_name : concern
         {
             context c = () =>
             {
                 service = the_dependency<CatalogTasks>();
                 request = an<Request>();
                 response_engine = the_dependency<ResponseEngine>();
                 provide_a_basic_sut_constructor_argument<Func<Request, IEnumerable<DepartmentItem>>>(x=>service.get_main_departments());

                 department_list = new List<DepartmentItem>();

                 service.Stub(service1 => service1.get_main_departments()).Return(department_list);
            
             };

             because b = () =>
             {
                 sut.process(request);
             };

        
             it first_observation = () =>
             {
                 response_engine.received(result1 => result1.display(department_list));
            
             };
             static Request request;
             static ResponseEngine response_engine;
             static CatalogTasks service;
             static IEnumerable<DepartmentItem> department_list;
             static  Func<Request, IEnumerable<DepartmentItem>> model_query;
         }
     }
=======
 namespace nothinbutdotnetstore.tests.web
 {   
   public class ViewModelDisplaySpecs
   {
     public abstract class concern : observations_for_a_sut_with_a_contract<contract_interface,
                                       contract_implementation>
     {
        
     }

     [Concern(typeof(contract_implementation))]
     public class when_observation_name : concern
     {
       context c = () =>
       {
            
       };

       because b = () =>
       {
        
       };

        
       it first_observation = () =>
       {
         
            
            
       };
     }
   }
>>>>>>> d0d42313525a0fa71722789c8e4bfa5c77c5fd59
 }
